namespace InteriorDesignPlanner.Client.Models
{
    public class DesignProjectViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Style { get; set; }

        public string RoomType { get; set; }

        public decimal Budget { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}