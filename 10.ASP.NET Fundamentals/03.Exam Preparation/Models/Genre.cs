using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; } = null!;
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
