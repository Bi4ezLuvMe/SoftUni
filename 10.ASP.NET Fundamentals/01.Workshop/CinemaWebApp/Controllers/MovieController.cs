using Microsoft.AspNetCore.Mvc;
using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CinemaWebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext context;
        
        public MovieController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await context.Movies.ToListAsync();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new MovieViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

            Movie movie = new Movie
            {
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                ReleaseDate = viewModel.ReleaseDate,
                Director = viewModel.Director,
                Duration = viewModel.Duration,
                Description = viewModel.Description
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            Movie? movie = await context.Movies.FindAsync(id);

            if(movie is null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpGet]
        public async Task<IActionResult> AddToProgram(int movieId)
        {
            Movie? movie = await context.Movies.FindAsync(movieId);

            if(movie is null)
            {
                return RedirectToAction("Index");
            }

            List<Cinema>cinemas = await context.Cinemas.ToListAsync();

            AddMovieToCinemaProgramViewModel viewModel = new AddMovieToCinemaProgramViewModel
            {
                MovieId = movie.Id,
                MovieTitle = movie.Title,
                Cinemas = cinemas.Select(c => new CinemaCheckBoxItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsSelected = false
                }).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaProgramViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            List<CinemaMovie> existingAssignments = await context.CinemaMovies.Where(x => x.MovieId == model.MovieId).ToListAsync();
            context.RemoveRange(existingAssignments);

            foreach (var cinema in model.Cinemas) 
            {
                if (cinema.IsSelected)
                {
                    CinemaMovie cinemaMovie = new CinemaMovie
                    {
                        MovieId = model.MovieId,
                        CinemaId = cinema.Id
                    };
                    await context.CinemaMovies.AddAsync(cinemaMovie);
                }
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
