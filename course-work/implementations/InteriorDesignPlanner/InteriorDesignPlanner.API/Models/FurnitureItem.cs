using System.ComponentModel.DataAnnotations;

namespace InteriorDesignPlanner.API.Models
{
    public class FurnitureItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Material { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? DesignProjectId { get; set; }

        public DesignProject? DesignProject { get; set; }
    }
}