using CinemaWebApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApp.Models
{
    public class UserMovie
    {
        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey("UserId"),Required]
        public ApplicationUser User { get; set; } = null!;
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("MovieId"),Required]
        public Movie Movie { get; set; } = null!;
    }
}
