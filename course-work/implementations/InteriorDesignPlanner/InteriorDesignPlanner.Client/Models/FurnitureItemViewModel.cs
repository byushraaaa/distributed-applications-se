namespace InteriorDesignPlanner.Client.Models
{
    public class FurnitureItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}