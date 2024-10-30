using CinemaWebApp.Common;
using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModels
{
    public class CinemaIndexViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage =ViewModelConstants.Cinema.NameRequiredError)]
        [MaxLength(ViewModelConstants.Cinema.NameMaxLength, ErrorMessage = ViewModelConstants.Cinema.NameMaxLengthError)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = ViewModelConstants.Cinema.LocationRequiredError)]
        [MaxLength(ViewModelConstants.Cinema.NameMaxLength, ErrorMessage = ViewModelConstants.Cinema.LocationMaxLengthError)]
        public string Location { get; set; } = null!;
    }
}
