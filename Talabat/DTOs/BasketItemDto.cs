using System.ComponentModel.DataAnnotations;

namespace Talabat.DTOs
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage ="Price must be greater than ZERO")]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Quantity must be atleast one item")]
        public int Quantity { get; set; }
    }
}