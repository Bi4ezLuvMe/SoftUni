using CinemaWebApp.Infrastructure.Repositories.Contracts;
using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWebApp.Infrastructure.Repositories
{
    public class CinemaMovieRepository : Repository<CinemaMovie>, ICinemaMovieRepository
    {
        private readonly AppDbContext context;
        public CinemaMovieRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public CinemaMovie GetFirstByMovieId(int id)
        {
            return context.CinemaMovies.FirstOrDefault(cm => cm.MovieId == id);
        }
    }
}
