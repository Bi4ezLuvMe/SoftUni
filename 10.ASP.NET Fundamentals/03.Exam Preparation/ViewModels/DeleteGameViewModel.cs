using Microsoft.AspNetCore.Identity;

namespace GameZone.ViewModels
{
    public class DeleteGameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public IdentityUser Publisher { get; set; } = null!;
    }

}
