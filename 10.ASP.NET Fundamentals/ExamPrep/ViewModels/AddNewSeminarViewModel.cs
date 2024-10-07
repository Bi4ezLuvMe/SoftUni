using Microsoft.AspNetCore.Identity;
using SeminarHub.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.ViewModels
{
    public class AddNewSeminarViewModel
    {
        public AddNewSeminarViewModel()
        {
            Categories = new List<Category>();
            DateAndTime = DateTime.Now;
        }
        [MinLength(3), MaxLength(100), Required]
        public string Topic { get; set; }
        [Required, MinLength(5), MaxLength(60)]
        public string Lecturer { get; set; }
        [Required, MinLength(10), MaxLength(500)]
        public string Details { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm"), Required]
        public DateTime DateAndTime { get; set; }
        [Range(30, 180)]
        public int Duration { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}
