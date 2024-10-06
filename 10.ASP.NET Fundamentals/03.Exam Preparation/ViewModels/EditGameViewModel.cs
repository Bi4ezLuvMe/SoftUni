using GameZone.Models;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class EditGameViewModel
    {
        public EditGameViewModel()
        {
            Genres = new List<Genre>();
        }
        public int Id { get; set; }
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
