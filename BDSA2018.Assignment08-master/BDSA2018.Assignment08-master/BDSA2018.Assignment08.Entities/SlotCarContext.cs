using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BDSA2018.Assignment08.Entities
{
    public class SlotCarContext : DbContext, ISlotCarContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<CarInRace> CarsInRace { get; set; }

        public SlotCarContext(DbContextOptions<SlotCarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarInRace>().HasKey(c => new { c.CarId, c.RaceId });

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Name = "Porsche 911 RSR", Driver = "Nick Tandy", Image = GetImage("c3944.5_1_1.jpg") },
                new Car { Id = 2, Name = "BMW Series 1 NGTC", Driver = "Colin Turkington", Image = GetImage("c3920.5_1_1.jpg") },
                new Car { Id = 3, Name = "Aston Martin Vantage GT3 (Oman Racing)", Driver = "Jonny Adam, Ahmad Al Harthy", Image = GetImage("c3843ae_1_autograph-series.jpg") },
                new Car { Id = 4, Name = "VW Passat", Driver = "Aron Smith", Image = GetImage("c3864_2_1.jpg") }
            );
        }

        private byte[] GetImage(string image)
        {
            return File.ReadAllBytes($"../Seed/{image}");
        }
    }
}
