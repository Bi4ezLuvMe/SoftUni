using CinemaWebApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWebApp.ViewModels
{
    public class EditMovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ViewModelConstants.Movie.TitleRequiredError)]
        [MaxLength(ViewModelConstants.Movie.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = ViewModelConstants.Movie.GenreRequiredError)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ViewModelConstants.Movie.ReleaseDateRequiredError)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = ViewModelConstants.Movie.DurationRequiredError)]
        [Range(ViewModelConstants.Movie.DurationRangeMin, ViewModelConstants.Movie.DurationRangeMax)]
        public int Duration { get; set; }

        [Required(ErrorMessage = ViewModelConstants.Movie.DirectorRequiredError)]
        [MaxLength(ViewModelConstants.Movie.DirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
