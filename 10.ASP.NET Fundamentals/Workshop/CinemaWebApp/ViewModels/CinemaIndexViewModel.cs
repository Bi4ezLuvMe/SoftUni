using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModels
{
    public class CinemaIndexViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Cinema name is required.")]
        [MaxLength(80,ErrorMessage ="Cinema name is too long.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(50, ErrorMessage = "Location is too long.")]
        public string Location { get; set; } = null!;
    }
}
