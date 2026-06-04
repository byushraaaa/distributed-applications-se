using System.ComponentModel.DataAnnotations;

namespace InteriorDesignPlanner.API.DTOs
{
    public class DesignProjectDto
    {
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

        [Range(0, 100000)]
        public decimal Budget { get; set; }
    }
}