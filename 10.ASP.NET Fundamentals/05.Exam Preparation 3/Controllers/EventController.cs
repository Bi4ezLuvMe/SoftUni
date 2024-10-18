using Homies.Common;
using Homies.Data;
using Homies.Models;
using Homies.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        public EventController(HomiesDbContext _context,UserManager<IdentityUser>_userManager)
        {
            this.context = _context;
            this.userManager = _userManager;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<EventViewModel> models = await context.Events
            .Select(e => new EventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start.ToString(ModelConstants.Event.DateTimeFormat),
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName,
            }).ToListAsync();

            return View(models);
        }
        [HttpPost]
        public async Task<IActionResult>Join(int id)
        {
            Event? ev = await context.Events.FindAsync(id);

            if(ev is null)
            {
                return RedirectToAction(nameof(All));
            }

            EventParticipant? ep = await context.EventsParticipants
                .Where(ep => ep.EventId == id && ep.HelperId == GetCurrentUserId())
                .FirstOrDefaultAsync();

            if(ep is not null)
            {
                return RedirectToAction(nameof(All));
            }

            ep = new EventParticipant()
            {
                EventId = id,
                HelperId = GetCurrentUserId(),
            };

            await context.EventsParticipants.AddAsync(ep);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            List<EventViewModel> models = await context.EventsParticipants
                .Include(ep => ep.Event)
                .Where(ep => ep.HelperId == GetCurrentUserId())
                .Select(ep => new EventViewModel()
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(ModelConstants.Event.DateTimeFormat),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName,
                }).ToListAsync();

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventAddViewModel model = new EventAddViewModel();

            model.Types = await PopulateTypes();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>Add(EventAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await PopulateTypes();
                return View(model);
            }

            Event ev = new Event()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = GetCurrentUserId(),
                CreatedOn = DateTime.Now,
            };

            await context.Events.AddAsync(ev);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            Event? ev = await context.Events.FindAsync(id);

            if(ev is null)
            {
                return RedirectToAction(nameof(All));
            }

            EventEditViewModel model = new EventEditViewModel()
            {
                Id = id,
                Name = ev.Name,
                Description = ev.Description,
                Start = ev.Start.ToString(ModelConstants.Event.DateTimeFormat),
                End = ev.End.ToString(ModelConstants.Event.DateTimeFormat),
                TypeId = ev.TypeId,
                Types = await PopulateTypes()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(EventEditViewModel model,int id)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await PopulateTypes();
                return View(model);
            }

            Event? ev = await context.Events.FindAsync(id);

            if(ev is null)
            {
                return RedirectToAction(nameof(All));
            }

            ev.Name = model.Name;
            ev.Description = model.Description;
            ev.Start = DateTime.Parse(model.Start);
            ev.End = DateTime.Parse(model.End);
            ev.TypeId = model.TypeId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult>Leave(int id)
        {
            EventParticipant? ep = await context.EventsParticipants
                .FirstOrDefaultAsync(ep=>ep.EventId==id&&ep.HelperId==GetCurrentUserId());

            if(ep is null)
            {
                return RedirectToAction(nameof(Joined));
            }

            context.EventsParticipants.Remove(ep);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            Event? ev = await context.Events.Include(e=>e.Organiser).Include(e=>e.Type).FirstOrDefaultAsync(e=>e.Id == id);

            if(ev is null)
            {
                return RedirectToAction(nameof(All));
            }

            EventDetailsViewModel model = new EventDetailsViewModel()
            {
                Id = id,
                Name = ev.Name,
                Description = ev.Description,
                Start = ev.Start.ToString(ModelConstants.Event.DateTimeFormat),
                End = ev.End.ToString(ModelConstants.Event.DateTimeFormat),
                CreatedOn = ev.CreatedOn.ToString(ModelConstants.Event.DateTimeFormat),
                Organiser = ev.Organiser.UserName,
                Type = ev.Type.Name,
            };

            return View(model);
        }
        private async Task<List<TypeViewModel>> PopulateTypes()
        {
             return await context.Types
            .Select(t => new TypeViewModel
            {
                Id = t.Id,
                Name = t.Name,
            }).ToListAsync();
        }
        private string GetCurrentUserId()
        {
            return userManager.GetUserId(User);
        }
    }
}
