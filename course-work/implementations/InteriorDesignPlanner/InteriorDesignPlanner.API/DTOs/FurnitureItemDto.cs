using System.ComponentModel.DataAnnotations;

namespace InteriorDesignPlanner.API.DTOs
{
    public class FurnitureItemDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Material { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        public bool IsAvailable { get; set; }
    }
}