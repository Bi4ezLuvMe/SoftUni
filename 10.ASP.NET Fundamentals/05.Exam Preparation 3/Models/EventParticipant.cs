using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Models
{
    public class EventParticipant
    {
        [Required]
        public string HelperId { get; set; } = null!;
        [Required]
        [ForeignKey("HelperId")]
        public IdentityUser Helper { get; set; } = null!;
        [Required]
        public int EventId { get; set; }
        [Required]
        [ForeignKey("EventId")]
        public Event Event { get; set; } = null!;
    }
}
