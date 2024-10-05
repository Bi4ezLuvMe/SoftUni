using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext context;
        public CinemaController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Cinema> cinemas = await context.Cinemas.ToListAsync();

            IEnumerable<CinemaIndexViewModel> cinemaIndexViewModels = cinemas.Select(c => new CinemaIndexViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Location = c.Location
            });

            return View(cinemaIndexViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CinemaIndexViewModel cinemaIndexModel)
        {
            if (ModelState.IsValid)
            {
                Cinema cinema = new Cinema
                {
                    Name = cinemaIndexModel.Name,
                    Location = cinemaIndexModel.Location
                };
                await context.Cinemas.AddAsync(cinema);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");   
            }
            return View(cinemaIndexModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await context.Cinemas.Include(c => c.CinemaMovies).ThenInclude(cm => cm.Movie).FirstOrDefaultAsync(c => c.Id == id);

            if(cinema is null)
            {
                return RedirectToAction("Index");
            }

            CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies.Select(cm=>new MovieProgramViewModel
                {
                    Title = cm.Movie.Title,
                    Duration = cm.Movie.Duration,
                }).ToList()
            };

            return View(cinemaDetailsViewModel);
        }
    }
}
