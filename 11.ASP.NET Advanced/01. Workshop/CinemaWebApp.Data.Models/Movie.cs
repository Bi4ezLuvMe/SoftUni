using CinemaWebApp.Data.Models;

namespace CinemaWebApp.Models
{
    public class Movie
    {
        public Movie()
        {
            ImageUrl = "~/images/no-image.jpg";
        }
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; } = null!;
        public int Duration { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public IList<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
        public IList<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
