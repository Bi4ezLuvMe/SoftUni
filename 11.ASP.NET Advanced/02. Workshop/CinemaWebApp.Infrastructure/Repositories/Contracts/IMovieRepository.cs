using CinemaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWebApp.Infrastructure.Repositories.Contracts
{
    public interface IMovieRepository:IRepository<Movie>
    {
    }
}
