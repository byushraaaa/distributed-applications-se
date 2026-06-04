using Microsoft.EntityFrameworkCore;
using InteriorDesignPlanner.API.Models;

namespace InteriorDesignPlanner.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<DesignProject> DesignProjects { get; set; }

        public DbSet<FurnitureItem> FurnitureItems { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
                .Property(r => r.Budget)
                .HasPrecision(18, 2);

            modelBuilder.Entity<DesignProject>()
                .Property(d => d.Budget)
                .HasPrecision(18, 2);

            modelBuilder.Entity<FurnitureItem>()
                .Property(f => f.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.DesignProjects)
                .WithOne(d => d.Room)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<DesignProject>()
                .HasMany(d => d.FurnitureItems)
                .WithOne(f => f.DesignProject)
                .HasForeignKey(f => f.DesignProjectId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}