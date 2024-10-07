using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public SeminarController(SeminarHubDbContext _context,UserManager<IdentityUser>_userManager)
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
        public async Task<IActionResult>Add(AddNewSeminarViewModel model)
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
            List<Seminar>seminars = await context.Seminars.Include(x=>x.Organizer).Include(x=>x.Category).ToListAsync();

            return View(seminars);
        }
    }
}
