using GameZone.Models;
using Microsoft.AspNetCore.Identity;

namespace GameZone.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
        public DateTime ReleasedOn { get; set; }
        public IdentityUser Publisher { get; set; }
        public string? ImageUrl { get; set; }
    }
}
