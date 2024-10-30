using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskMarket.Models
{
    public class ProductClient
    {
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        [Required]
        public string ClientId { get; set; } = null!;
        [ForeignKey("ClientId")]
        public IdentityUser Client { get; set; } = null!;
    }
}