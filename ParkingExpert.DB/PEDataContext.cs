using ParkingExpert.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace ParkingExpert.DB
{
    public class PEDataContext : DbContext
    {
        public PEDataContext(DbContextOptions<PEDataContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Settings>()
                .HasData(
                    new Settings
                    {
                        Id = 1,
                        PricePerHour = 10,
                        ParkingCapacity = 50
                    });
        }
    }
}