using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class Category
    {
        public Category()
        {
            Seminars = new List<Seminar>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; } = null!;
        public List<Seminar> Seminars { get; set; }
    }
}