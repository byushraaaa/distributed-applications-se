using System.ComponentModel.DataAnnotations;

namespace InteriorDesignPlanner.API.DTOs
{
    public class RoomDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Range(1, 1000)]
        public double Size { get; set; }

        [Required]
        [MaxLength(50)]
        public string Style { get; set; }

        [Range(0, 100000)]
        public decimal Budget { get; set; }
    }
}