using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]  // Helps EF Core map to SQL decimal type
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }

        // Optional: Foreign Key if you have a Category table
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
