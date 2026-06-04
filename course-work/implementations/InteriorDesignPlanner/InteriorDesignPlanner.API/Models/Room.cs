using System.ComponentModel.DataAnnotations;

namespace InteriorDesignPlanner.API.Models
{
    public class Room
    {
        public int Id { get; set; }

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

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<DesignProject> DesignProjects { get; set; } = new();
    }

}