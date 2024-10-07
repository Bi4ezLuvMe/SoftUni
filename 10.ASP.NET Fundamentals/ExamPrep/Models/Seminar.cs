using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Models
{
    public class Seminar
    {
        public Seminar()
        {
            SeminarParticipants = new List<SeminarParticipant>();
        }
        [Key]
        public int Id { get; set; }
        [MinLength(3),MaxLength(100),Required]
        public string Topic { get; set; }
        [Required,MinLength(5),MaxLength(60)]
        public string Lecturer { get; set; }
        [Required,MinLength(10),MaxLength(500)]
        public string Details { get; set; }
        [Required]
        public string OrganizerId { get; set; }
        [ForeignKey("OrganizerId"),Required]
        public IdentityUser Organizer { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm"),Required]
        public DateTime DateAndTime { get; set; }
        [Range(30,180)]
        public int Duration { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required,ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<SeminarParticipant> SeminarParticipants { get; set; }
    }
}
