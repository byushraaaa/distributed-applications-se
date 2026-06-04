using System.ComponentModel.DataAnnotations;

namespace InteriorDesignPlanner.API.Models
{
    public class DesignProject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Style { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoomType { get; set; }

        public decimal Budget { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? RoomId { get; set; }

        public Room? Room { get; set; }

        public List<FurnitureItem> FurnitureItems { get; set; } = new();
    }
}