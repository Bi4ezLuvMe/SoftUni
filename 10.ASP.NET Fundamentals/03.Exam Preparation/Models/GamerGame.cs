using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class GamerGame
    {
        [Required]
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        [Required]
        public string GamerId { get; set; }
        [ForeignKey("GamerId")]
        public IdentityUser Gamer { get; set; }
    }
}
