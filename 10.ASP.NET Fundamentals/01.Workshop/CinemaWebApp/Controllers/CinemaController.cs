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
        public IActionResult Index()
        {
            List<Cinema> cinemas = context.Cinemas.ToList();

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
        public IActionResult Create(CinemaIndexViewModel cinemaIndexModel)
        {
            if (ModelState.IsValid)
            {
                Cinema cinema = new Cinema
                {
                    Name = cinemaIndexModel.Name,
                    Location = cinemaIndexModel.Location
                };
                context.Cinemas.Add(cinema);
                context.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View(cinemaIndexModel);
        }
        public IActionResult Details(int id)
        {
            var cinema = context.Cinemas.Include(c => c.CinemaMovies).ThenInclude(cm => cm.Movie).FirstOrDefault(c => c.Id == id);

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
