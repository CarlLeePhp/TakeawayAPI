using Microsoft.AspNetCore.Identity;

namespace TakeawayAPI.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; } = null!;
    }
}
