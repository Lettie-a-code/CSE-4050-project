using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.Models
{
    // Id (string, by default GUID)
    // UserName
    // Email
    // PasswordHash
    // PhoneNumber
    // + all Identity built-in fields (EmailConfirmed, Lockout, etc.)

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(1)]
        public string? MiddleInitial { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Address1 { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [MaxLength(2)]
        public string State { get; set; } = string.Empty;

        [MaxLength(10)]
        public string PostalCode { get; set; } = string.Empty;

        public DateTime DateRegistered { get; set; } = DateTime.Now;
    }
}

