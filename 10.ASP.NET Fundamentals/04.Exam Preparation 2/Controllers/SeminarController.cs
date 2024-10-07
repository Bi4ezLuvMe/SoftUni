using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using SeminarHub.Data;
using SeminarHub.Models;
using SeminarHub.ViewModels;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        public SeminarController(SeminarHubDbContext _context, UserManager<IdentityUser> _userManager)
        {
            this.context = _context;
            this.userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddNewSeminarViewModel model = new AddNewSeminarViewModel();

            model.Categories = await context.Categories.ToListAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddNewSeminarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await context.Categories.ToListAsync();
                return View(model);
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Seminar seminar = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = model.DateAndTime,
                Duration = model.Duration,
                CategoryId = model.CategoryId,
                OrganizerId = userId,
            };

            await context.Seminars.AddAsync(seminar);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<Seminar> seminars = await context.Seminars.Include(x => x.Organizer).Include(x => x.Category).ToListAsync();

            return View(seminars);
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            List<Seminar>joined = await context.SeminarParticipants.Include(x=>x.Seminar).ThenInclude(x=>x.Organizer).Where(x=>x.ParticipantId== User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(x=>x.Seminar).ToListAsync();
            return View(joined);

        }
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            Seminar? seminar = await context.Seminars.FindAsync(id);

            if(seminar is null)
            {
                return RedirectToAction("Joined");
            }

            SeminarParticipant seminarParticipant = new SeminarParticipant()
            {
                SeminarId = id,
                ParticipantId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            if (await context.SeminarParticipants.ContainsAsync(seminarParticipant))
            {
                return RedirectToAction("Joined");
            }

            await context.SeminarParticipants.AddAsync(seminarParticipant);
            await context.SaveChangesAsync();

            return RedirectToAction("Joined");
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            Seminar? seminar = await context.Seminars.FindAsync(id);

            if(seminar is null)
            {
                return RedirectToAction("All");
            }

            EditSeminarViewModel editModel = new EditSeminarViewModel()
            {
                Id = id,
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = seminar.DateAndTime,
                Duration = seminar.Duration,
                CategoryId = seminar.CategoryId,
                Categories = await context.Categories.ToListAsync()
            };

            return View(editModel);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(EditSeminarViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                editModel.Categories = await context.Categories.ToListAsync();
                return View(editModel);
            }

            Seminar seminar = await context.Seminars.FindAsync(editModel.Id);

            seminar.Topic = editModel.Topic;
            seminar.Lecturer = editModel.Lecturer;
            seminar.Details = editModel.Details;
            seminar.DateAndTime = editModel.DateAndTime;
            seminar.Duration = editModel.Duration;
            seminar.Category = editModel.Categories.FirstOrDefault(x => x.Id == editModel.CategoryId);

            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            Seminar? seminar = await context.Seminars.FindAsync(id);

            if(seminar is null)
            {
                return RedirectToAction("All");
            }

            SeminarParticipant? seminarParticipant = await context.
                SeminarParticipants
                .FirstOrDefaultAsync(x => x.SeminarId == id && x.ParticipantId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            context.SeminarParticipants.Remove(seminarParticipant);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Seminar? seminar = await context.Seminars.FindAsync(id);

            if(seminar is null)
            {
                return RedirectToAction("All");
            }
            List<Category> categories = await context.Categories.ToListAsync();
            SeminarDetailsViewModel model = new SeminarDetailsViewModel()
            {
                Id = id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime,
                Duration = seminar.Duration,
                Lecturer = seminar.Lecturer,
                Category = categories.FirstOrDefault(x=>x.Id==seminar.CategoryId).Name,
                Details = seminar.Details,
                Organizer = userManager.FindByIdAsync(seminar.OrganizerId).Result.UserName               
                //Organizer = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Seminar? seminar = await context.Seminars.FindAsync(id);
            if(seminar is null)
            {
                return RedirectToAction("All");
            }
            DeleteSeminarViewModel deleteModel = new DeleteSeminarViewModel()
            {
                Id = id,
                Topic = seminar.Topic,
                DateAndTime = seminar.DateAndTime
            };
            return View(deleteModel);
        }
        [HttpPost]
        public async Task<IActionResult>DeleteConfirmed(DeleteSeminarViewModel model)
        {
            Seminar? seminar = await context.Seminars.FindAsync(model.Id);
            List<SeminarParticipant> seminarParticipants = await context.SeminarParticipants.Where(x => x.SeminarId == model.Id).ToListAsync();
            context.SeminarParticipants.RemoveRange(seminarParticipants);
            context.Seminars.Remove(seminar);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}