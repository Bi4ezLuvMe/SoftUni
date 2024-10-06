using GameZone.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.ViewModels
{
    public class AddToMyZoneViewModel
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public string GamerId { get; set; }
    }
}
