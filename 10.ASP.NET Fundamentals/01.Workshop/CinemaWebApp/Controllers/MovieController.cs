using Microsoft.AspNetCore.Mvc;
using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CinemaWebApp.ViewModels;

namespace CinemaWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext context;
        
        public MovieController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var movies = context.Movies.ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new MovieViewModel());
        }
        [HttpPost]
        public IActionResult Create(MovieViewModel viewModel)
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
            context.Movies.Add(movie);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            Movie movie = context.Movies.Find(id);

            if(movie is null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpGet]
        public IActionResult AddToProgram(int movieId)
        {
            Movie movie = context.Movies.Find(movieId);
            if(movie is null)
            {
                return RedirectToAction("Index");
            }
            List<Cinema>cinemas = context.Cinemas.ToList();
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
        public IActionResult AddToProgram(AddMovieToCinemaProgramViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            List<CinemaMovie> existingAssignments = context.CinemaMovies.Where(x => x.MovieId == model.MovieId).ToList();
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
                    context.CinemaMovies.Add(cinemaMovie);
                }
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
