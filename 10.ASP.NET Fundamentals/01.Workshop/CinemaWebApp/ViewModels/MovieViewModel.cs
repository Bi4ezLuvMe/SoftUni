﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            ReleaseDate = DateTime.Now;
        }
        [Required(ErrorMessage ="Movie title is required.")]
        [MaxLength(100,ErrorMessage ="Movie title is too long.")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage ="Genre is required.")]
        public string Genre { get; set; } = null!;
        [Required(ErrorMessage = "Release date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Director is required.")]
        [MaxLength(100,ErrorMessage ="Director name is too long.")]
        public string Director { get; set; } = null!;
        [Required(ErrorMessage = "Duration for the movie is required.")]
        [Range(1,500,ErrorMessage = "Duration for the movie must be between 1 and 500 minutes.")]
        public int Duration { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
