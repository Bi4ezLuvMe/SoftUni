using CinemaWebApp.Data.Models;
using CinemaWebApp.Infrastructure.Repositories.Contracts;
using CinemaWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWebApp.Infrastructure.Repositories
{
    public class TicketRepository : Repository<Ticket>,ITicketRepository
    {
        public TicketRepository(AppDbContext context) : base(context)
        {
        }
    }
}
