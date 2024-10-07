using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Models
{
    public class SeminarParticipant
    {
        [Required]
        public int SeminarId { get; set; }
        [ForeignKey("SeminarId"), Required]
        public Seminar Seminar { get; set; } = null!;
        [Required]
        public string ParticipantId { get; set; } = null!;
        [ForeignKey("ParticipantId"), Required]
        public IdentityUser Participant { get; set; } = null!;
    }
}