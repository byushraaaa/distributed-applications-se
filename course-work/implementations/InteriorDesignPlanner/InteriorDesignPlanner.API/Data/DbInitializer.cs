using InteriorDesignPlanner.API.Models;

namespace InteriorDesignPlanner.API.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room
                    {
                        Name = "Modern Living Room",
                        Type = "Living Room",
                        Size = 45,
                        Style = "Modern",
                        Budget = 15000
                    },

                    new Room
                    {
                        Name = "Minimalist Bedroom",
                        Type = "Bedroom",
                        Size = 30,
                        Style = "Minimalist",
                        Budget = 10000
                    }
                );

                context.SaveChanges();
            }

            if (!context.DesignProjects.Any())
            {
                context.DesignProjects.AddRange(
                    new DesignProject
                    {
                        Title = "Luxury Apartment",
                        Description = "Luxury modern apartment design",
                        Style = "Modern",
                        RoomType = "Apartment",
                        Budget = 50000
                    },

                    new DesignProject
                    {
                        Title = "Cozy Family House",
                        Description = "Warm Scandinavian family home",
                        Style = "Scandinavian",
                        RoomType = "House",
                        Budget = 70000
                    }
                );

                context.SaveChanges();
            }

            if (!context.FurnitureItems.Any())
            {
                context.FurnitureItems.AddRange(
                    new FurnitureItem
                    {
                        Name = "Modern Sofa",
                        Category = "Sofa",
                        Price = 2500,
                        Material = "Leather",
                        Color = "Black",
                        IsAvailable = true
                    },

                    new FurnitureItem
                    {
                        Name = "Wooden Dining Table",
                        Category = "Table",
                        Price = 1800,
                        Material = "Wood",
                        Color = "Brown",
                        IsAvailable = true
                    }
                );

                context.SaveChanges();
            }
        }
    }
}