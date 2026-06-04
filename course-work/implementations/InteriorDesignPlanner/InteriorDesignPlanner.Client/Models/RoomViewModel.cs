namespace InteriorDesignPlanner.Client.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public double Size { get; set; }

        public string Style { get; set; }

        public decimal Budget { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}