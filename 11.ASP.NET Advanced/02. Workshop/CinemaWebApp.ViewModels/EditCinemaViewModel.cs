using CinemaWebApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWebApp.ViewModels
{
    public class EditCinemaViewModel
    {
        [Required(ErrorMessage = ViewModelConstants.Cinema.NameRequiredError)]
        public int Id { get; set; }
        [Required]
        [MaxLength(ViewModelConstants.Cinema.NameMaxLength, ErrorMessage = ViewModelConstants.Cinema.NameMaxLengthError)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = ViewModelConstants.Cinema.LocationRequiredError)]
        [MaxLength(ViewModelConstants.Cinema.LocationMaxLength, ErrorMessage = ViewModelConstants.Cinema.LocationMaxLengthError)]
        public string Location { get; set; } = null!;
    }
}
