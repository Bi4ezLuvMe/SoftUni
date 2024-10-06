using GameZone.Data;
using GameZone.Models;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public GameController(GameZoneDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddGameViewModel
            {
                ReleasedOn = DateTime.Now,
                Genres = await _context.Genres.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel gameViewModel)
        {
            if (!ModelState.IsValid)
            {
                gameViewModel.Genres = await _context.Genres.ToListAsync();
                return View(gameViewModel);
            }


            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IdentityUser user = await _userManager.FindByIdAsync(userId);


            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == gameViewModel.GenreId);

            if (genre == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid genre selected.");
                gameViewModel.Genres = await _context.Genres.ToListAsync();
                return View(gameViewModel);
            }

            var game = new Game
            {
                Title = gameViewModel.Title,
                ImageUrl = gameViewModel.ImageUrl,
                Description = gameViewModel.Description,
                ReleasedOn = gameViewModel.ReleasedOn,
                PublisherId = userId,
                GenreId = gameViewModel.GenreId,
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var games = await _context.Games.Include(g => g.Genre).Include(g => g.Publisher).ToListAsync();

            return View(games);
        }
        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var games = await _context.GamersGames
         .Include(x => x.Game)
         .ThenInclude(g => g.Publisher)  
         .Include(x => x.Game.Genre)      
         .Where(x => x.GamerId == userId)
         .Select(x => x.Game)
         .ToListAsync();
            return View(games);
        }
        [HttpGet]
        [Route("Game/AddToMyZone/{gameId}")]
        public async Task<IActionResult> AddToMyZone(int gameId)
        {
            GamerGame gamerGame = new GamerGame
            {
                GamerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                GameId = gameId
            };

            if (await _context.GamersGames.ContainsAsync(gamerGame))
            {
                return RedirectToAction("All");
            }
            await _context.GamersGames.AddAsync(gamerGame);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyZone");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Game? game = await _context.Games.Include(g=>g.Genre).FirstOrDefaultAsync(x=>x.Id==id);
            if(game is null)
            {
                return RedirectToAction("All");
            }
            EditGameViewModel model = new EditGameViewModel
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                ReleasedOn = game.ReleasedOn,
                GenreId = game.GenreId,
                Genres = await _context.Genres.ToListAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await _context.Genres.ToListAsync();
                return View(model);
            }
            Game? game = await _context.Games.FindAsync(model.Id);
            if(game is null)
            {
                RedirectToAction("All");
            }

            game.Title = model.Title;
            game.Description = model.Description;
            game.ImageUrl = model.ImageUrl;
            game.ReleasedOn = model.ReleasedOn;
            game.GenreId = model.GenreId;

            await _context.SaveChangesAsync();
            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            GamerGame? gamerGame = await _context.GamersGames.Where(x=>x.GamerId == userId&&x.GameId==id).FirstOrDefaultAsync();

            if(gamerGame is null)
            {
                return RedirectToAction("MyZone");
            }

            _context.GamersGames.Remove(gamerGame);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyZone");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Game? game = await _context.Games.Include(x=>x.Publisher).Include(x=>x.Genre).FirstOrDefaultAsync(x => x.Id == id);

            if(game is null)
            {
                return RedirectToAction("All");
            }

            GameDetailsViewModel model = new GameDetailsViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                ReleasedOn = game.ReleasedOn,
                Publisher = game.Publisher,
                Genre = game.Genre
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Game? game = await _context.Games.Include(x=>x.Publisher).FirstOrDefaultAsync(x => x.Id == id);

            if (game is null)
            {
                return RedirectToAction("All");
            }

            DeleteGameViewModel model = new DeleteGameViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Publisher = game.Publisher
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteGameViewModel model)
        {

            Game? game = await _context.Games.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (game is null)
            {
                return RedirectToAction("All");
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}
