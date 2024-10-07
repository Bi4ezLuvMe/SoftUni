using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SeminarHub.Models;

namespace SeminarHub.ViewModels
{
    public class SeminarDetailsViewModel
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public int Duration { get; set; }
        public string Lecturer { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Organizer { get; set; }
    }
}
