using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShoppingCartAPI.Models
{
    public class CustomerProfile
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }

        // Link to Identity user
        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        public IdentityUser? User { get; set; }
    }
}
