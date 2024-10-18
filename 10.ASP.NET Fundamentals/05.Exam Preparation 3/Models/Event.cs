using Homies.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(ModelConstants.Event.NameMinLength)]
        [MaxLength(ModelConstants.Event.NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(ModelConstants.Event.DescriptionMinLength)]
        [MaxLength(ModelConstants.Event.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        public string OrganiserId { get; set; } = null!;
        [Required]
        [ForeignKey("OrganiserId")]
        public IdentityUser Organiser { get; set; } = null!;
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        [ForeignKey("TypeId")]
        public Type Type { get; set; } = null!;
        public IList<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
    }
}
