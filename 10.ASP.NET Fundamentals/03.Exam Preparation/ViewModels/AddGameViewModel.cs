using GameZone.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GameZone.Data;

namespace GameZone.ViewModels
{
    public class AddGameViewModel
    {
        public AddGameViewModel()
        {
            Genres = new List<Genre>();
        }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        [Required]
        public DateTime ReleasedOn { get; set; }
        [Required]
        public int GenreId { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
