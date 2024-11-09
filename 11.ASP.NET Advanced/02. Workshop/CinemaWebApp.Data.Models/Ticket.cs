using CinemaWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWebApp.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; } = null!;
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; } = null!;
        [ForeignKey("UserId")]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
