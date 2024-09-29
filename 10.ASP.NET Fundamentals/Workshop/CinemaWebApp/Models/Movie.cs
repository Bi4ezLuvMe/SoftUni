﻿namespace CinemaWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public List<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
    }
}