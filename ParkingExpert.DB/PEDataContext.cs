using System.Collections.Generic;
using ParkingExpert.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ParkingExpert.DB
{
    public class PEDataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public PEDataContext(DbContextOptions<PEDataContext> options, 
            IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
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
                        PricePerHour = 10
                    });

            var parkingCapacity = int.Parse(_configuration["ParkingCapacity"]);
            var parking = new List<ParkingPlace>();
            for (var i = 1; i <= parkingCapacity; i++)
            {
                parking.Add(new ParkingPlace
                {
                    Id = i,
                    IsAvailable = true
                });
            }
            modelBuilder.Entity<ParkingPlace>()
                .HasData(parking);
        }
    }
}