using CinemaWebApp.Infrastructure.Repositories.Contracts;
using CinemaWebApp.Models;
using CinemaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepostory;
        private readonly ICinemaRepository cinemaRepository;
        private readonly ICinemaMovieRepository cinemaMovieRepository;

        public MovieController(IMovieRepository _repository, ICinemaRepository _cinemaRepository, ICinemaMovieRepository _cinemaMovieRepository)
        {
            this.movieRepostory = _repository;
            this.cinemaRepository = _cinemaRepository;
            this.cinemaMovieRepository = _cinemaMovieRepository;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await movieRepostory.GetAllAsync();
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
                    Description = viewModel.Description,
                    ImageUrl = viewModel.ImageUrl,
                };

                await movieRepostory.AddAsync(movie);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            Movie? movie = await movieRepostory.GetByIdAsync(id);

            if (movie is null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpGet]
        public async Task<IActionResult> AddToProgram(int movieId)
        {
            Movie? movie = await movieRepostory.GetByIdAsync(movieId);

            if (movie is null)
            {
                return RedirectToAction("Index");
            }

            List<Cinema> cinemas = (List<Cinema>)await cinemaRepository.GetAllAsync();

            AddMovieToCinemaProgramViewModel viewModel = new AddMovieToCinemaProgramViewModel
            {
                MovieId = movie.Id,
                MovieTitle = movie.Title,
                Cinemas = cinemas.Select(c => new CinemaCheckBoxItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsSelected = IsSelected(c.Id)
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
            List<CinemaMovie> existingAssignments = (List<CinemaMovie>)await cinemaMovieRepository.GetAllAsync();


            existingAssignments = existingAssignments.Where(x => x.MovieId == model.MovieId).ToList();
            foreach (CinemaMovie cm in existingAssignments)
            {
                await cinemaMovieRepository.DeleteAsync(cm);
            }

            foreach (var cinema in model.Cinemas)
            {
                if (cinema.IsSelected)
                {
                    CinemaMovie cinemaMovie = new CinemaMovie
                    {
                        MovieId = model.MovieId,
                        CinemaId = cinema.Id
                    };
                    await cinemaMovieRepository.AddAsync(cinemaMovie);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            IEnumerable<Movie> cinemas = (IEnumerable<Movie>)await movieRepostory.GetAllAsync();
            return View(cinemas);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Movie movie = await movieRepostory.GetByIdAsync(id);

            EditMovieViewModel model = new EditMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                Duration = movie.Duration,
                Genre = movie.Genre,
                ImageUrl = movie.ImageUrl,
                ReleaseDate = movie.ReleaseDate,
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Manage));
            }
            Movie movie = await movieRepostory.GetByIdAsync(model.Id);

            movie.Title = model.Title;
            movie.Description = model.Description;
            movie.Director = model.Director;
            movie.Duration = model.Duration;
            movie.Genre = model.Genre;
            if(model.ImageUrl is not null)
            {
            movie.ImageUrl = model.ImageUrl;
            }
            movie.ReleaseDate = model.ReleaseDate;

            await movieRepostory.UpdateAsync(movie);

            return RedirectToAction(nameof(Manage));
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            Movie movie = await movieRepostory.GetByIdAsync(id);
           
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(Movie movie)
        {
           await movieRepostory.DeleteAsync(movie);
            return RedirectToAction(nameof(Manage));
        }
        private bool IsSelected(int movieId)
        {
            return cinemaMovieRepository.GetFirstByMovieId(movieId) == null ? false : true;
        }
    }
}
