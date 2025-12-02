using System.ComponentModel.DataAnnotations;

namespace MyEcommerceAPI.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } =string.Empty;

        [Range(0.0, 1000000.0)]
        public decimal Price { get; set; }
    }
}
