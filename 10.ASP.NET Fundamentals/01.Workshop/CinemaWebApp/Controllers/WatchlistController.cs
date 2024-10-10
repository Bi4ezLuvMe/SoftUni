using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Controllers
{
    public class WatchlistController:Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        public WatchlistController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            string userId = userManager.GetUserId(User);

           var watchListMovies = await context.UsersMovies
                .Where(um=>um.UserId == userId)
                .Include(um=>um.Movie)
                .Select(um=>new WatchListViewModel
            {
                MovieId = um.MovieId,
                Title = um.Movie.Title,
                Genre = um.Movie.Genre,
                ReleaseDate = um.Movie.ReleaseDate.ToString("MMMM yyyy"),
                ImageUrl = um.Movie.ImageUrl
            }).ToListAsync();

            return View(watchListMovies);
        }
        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(int movieId)
        {
            string userId = userManager.GetUserId(User);

            UserMovie? userMovie = await context.UsersMovies.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);

            if (userMovie == null)
            {
                userMovie = new UserMovie
                {
                    UserId = userId,
                    MovieId = movieId,
                };

                await context.UsersMovies.AddAsync(userMovie);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Movie");
        }
        [HttpPost]
        public async Task<IActionResult>RemoveFromWatchlist(int movieId)
        {
            string userId = userManager.GetUserId(User);

            UserMovie? userMovie = await context.UsersMovies.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);

            if(userMovie != null)
            {
                context.UsersMovies.Remove(userMovie);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
