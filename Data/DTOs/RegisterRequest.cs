using System.ComponentModel.DataAnnotations;

namespace TakeawayAPI.Data.DTOs
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;
    }
}
