using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class Game
    {
        [Key]
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
        public string PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        [Required]
        public IdentityUser Publisher { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="yyyy-MM-dd")]
        public DateTime ReleasedOn { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public List<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
    }
}
