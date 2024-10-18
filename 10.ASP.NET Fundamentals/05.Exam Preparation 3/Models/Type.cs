using Homies.Common;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(ModelConstants.Type.NameMinLength)]
        [MaxLength(ModelConstants.Type.NameMaxLength)]
        public string Name { get; set; } = null!;
        public IList<Event> Events { get; set; } = new List<Event>();
    }
}
