using System.ComponentModel.DataAnnotations;

namespace ShoppingCartAPI.Models
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(150)]
        public string Address { get; set; } = string.Empty;

        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;
    }
}

