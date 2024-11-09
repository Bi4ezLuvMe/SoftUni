using CinemaWebApp.Infrastructure.Repositories;
using CinemaWebApp.Infrastructure.Repositories.Contracts;
using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CinemaWebApp.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository repository;
        private readonly ICinemaMovieRepository cinemaMovieRepository;
        private readonly IMovieRepository movieRepository;
        public CinemaController(ICinemaRepository _repository, ICinemaMovieRepository _cinemaMovieRepository, IMovieRepository _movieRepository)
        {
            this.repository = _repository;
            this.cinemaMovieRepository = _cinemaMovieRepository;
            this.movieRepository = _movieRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Cinema> cinemas = (List<Cinema>)await repository.GetAllAsync();

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
                await repository.AddAsync(cinema);
                return RedirectToAction("Index");   
            }
            return View(cinemaIndexModel);
        }
        public async Task<IActionResult> Details(int id)
        {
            var cinema = await repository.GetByIdAsync(id);
            var mp = await cinemaMovieRepository.GetAllAsync();

            mp = mp.Where(x => x.CinemaId == id).ToList();

            if(cinema is null)
            {
                return RedirectToAction("Index");
            }

            CinemaDetailsViewModel cinemaDetailsViewModel = new CinemaDetailsViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = mp.Select(cm=>new MovieProgramViewModel()
                {
                    Title = GetMovieNameAndDurationById(cm.MovieId).Result.Item1,
                    Duration = GetMovieNameAndDurationById(cm.MovieId).Result.Item2,
                }).ToList()
            };

            return View(cinemaDetailsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            IEnumerable<Cinema> cinemas = (IEnumerable<Cinema>)await repository.GetAllAsync();
            return View(cinemas);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Cinema cinema = await repository.GetByIdAsync(id);

            EditCinemaViewModel model = new EditCinemaViewModel
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
            };

            return View(model); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(EditCinemaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Manage));
            }
            Cinema cinema = await repository.GetByIdAsync(model.Id);

            cinema.Name = model.Name;
            cinema.Location = model.Location;

            await repository.UpdateAsync(cinema);
            return RedirectToAction(nameof(Manage));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Cinema cinema = await repository.GetByIdAsync(id);

            return View(cinema);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Cinema cinema)
        {
            await repository.DeleteAsync(cinema);
            return RedirectToAction(nameof(Manage));
        }
        private async Task<(string,int)> GetMovieNameAndDurationById(int id)
        {
           Movie movie = await movieRepository.GetByIdAsync(id);

            return (movie.Title, movie.Duration);
        }
    }
}
