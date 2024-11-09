using CinemaWebApp.Common;
using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            ReleaseDate = DateTime.Now;
        }
        [Required(ErrorMessage =ViewModelConstants.Movie.TitleRequiredError)]
        [MaxLength(ViewModelConstants.Movie.TitleMaxLength, ErrorMessage = ViewModelConstants.Movie.TitleMaxLengthError)]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = ViewModelConstants.Movie.GenreRequiredError)]
        public string Genre { get; set; } = null!;
        [Required(ErrorMessage = ViewModelConstants.Movie.ReleaseDateRequiredError)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = ViewModelConstants.Movie.DirectorRequiredError)]
        [MaxLength(ViewModelConstants.Movie.DirectorMaxLength, ErrorMessage = ViewModelConstants.Movie.DirectorMaxLengthError)]
        public string Director { get; set; } = null!;
        [Required(ErrorMessage = ViewModelConstants.Movie.DurationRequiredError)]
        [Range(ViewModelConstants.Movie.DurationRangeMin, ViewModelConstants.Movie.DurationRangeMax, ErrorMessage = ViewModelConstants.Movie.DurationRangeError)]
        public int Duration { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
