using CinemaWebApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaMovie> CinemaMovies { get; set; }
        public DbSet<UserMovie> UsersMovies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserMovie>().HasKey(um => new { um.MovieId, um.UserId });

            modelBuilder.Entity<CinemaMovie>().HasKey(cm => new { cm.CinemaId, cm.MovieId });

            modelBuilder.Entity<CinemaMovie>().HasOne(cm => cm.Cinema).WithMany(c => c.CinemaMovies).HasForeignKey(cm => cm.CinemaId);

            modelBuilder.Entity<CinemaMovie>().HasOne(cm => cm.Movie).WithMany(m => m.CinemaMovies).HasForeignKey(cm => cm.MovieId);
        }
    }
}
