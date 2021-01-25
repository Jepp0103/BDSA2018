using Microsoft.EntityFrameworkCore;

namespace BDSA2018.Assignment04.Entities
{
    public class SlotCarContext : DbContext
    {
        private readonly bool useInMemoryDb;
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarInRace> CarsInRaces { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public SlotCarContext() : base()
        {
            useInMemoryDb = false;
        }

        public SlotCarContext(DbContextOptions<SlotCarContext> options) : base(options)
        {
            useInMemoryDb = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!useInMemoryDb) optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SlotCar;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarInRace>().HasKey("CarId", "RaceId");

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            Car car1 = new Car { DriverName = "Danny", Id = 1, Name = "Fast car" };
            Car car2 = new Car { DriverName = "Mymo", Id = 2, Name = "Slow car" };
            Car car3 = new Car { DriverName = "Theodor", Id = 3, Name = "Kicked car" };
            Car car4 = new Car { DriverName = "Historian", Id = 4, Name = "Lore car" };
            Car car5 = new Car { DriverName = "Mememechin", Id = 5, Name = "Dank car" };
            var cars = new[] { car1, car2, car3, car4, car5 };
            Cars.AddRange(cars);

            Track track1 = new Track { Id = 1, Name = "Short track", BestLapTime = 10000000000, Length = 3500, MaxCars = 8 };
            Track track2 = new Track { Id = 2, Name = "Medium track", BestLapTime = 30000000000, Length = 7000, MaxCars = 16 };
            Track track3 = new Track { Id = 3, Name = "Long track", BestLapTime = 50000000000, Length = 10500, MaxCars = 32 };
            var tracks = new[] { track1, track2, track3 };
            Tracks.AddRange(tracks);

            Race race1 = new Race { Id = 1, Track = track1, NumberOfLaps = 99 };
            Race race2 = new Race { Id = 2, Track = track2, NumberOfLaps = 30 };
            Race race3 = new Race { Id = 3, Track = track2, NumberOfLaps = 55 };
            Race race4 = new Race { Id = 4, Track = track3, NumberOfLaps = 32 };
            Race race5 = new Race { Id = 5, Track = track3, NumberOfLaps = 18 };
            Race race6 = new Race { Id = 6, Track = track3, NumberOfLaps = 12 };
            var races = new[] { race1, race2, race3, race4, race5, race6 };
            Races.AddRange(races);

            CarInRace cir1 = new CarInRace { CarId = car1.Id, RaceId = race1.Id, Race = race1, StartPosition = 1, EndPosition = 1, BestLap = 10000000000, TotalRaceTime = 1100000000000 };
            CarInRace cir2 = new CarInRace { CarId = car3.Id, RaceId = race1.Id, Race = race1, StartPosition = 2, EndPosition = 2, BestLap = 25000000000, TotalRaceTime = 1500000000000 };
            CarInRace cir3 = new CarInRace { CarId = car5.Id, RaceId = race1.Id, Race = race1, StartPosition = 3, EndPosition = 3, BestLap = 13000000000, TotalRaceTime = 1300000000000 };
            CarInRace cir4 = new CarInRace { CarId = car1.Id, RaceId = race2.Id, Race = race2, StartPosition = 4, EndPosition = 1, BestLap = 100000000000, TotalRaceTime = 1200000000000 };
            CarInRace cir5 = new CarInRace { CarId = car2.Id, RaceId = race2.Id, Race = race2, StartPosition = 3, EndPosition = 2, BestLap = 58000000000, TotalRaceTime = 900000000000 };
            CarInRace cir6 = new CarInRace { CarId = car4.Id, RaceId = race2.Id, Race = race2, StartPosition = 2, EndPosition = 3, BestLap = 30000000000, TotalRaceTime = 5000000000000 };
            CarInRace cir7 = new CarInRace { CarId = car5.Id, RaceId = race2.Id, Race = race2, StartPosition = 1, EndPosition = 4, BestLap = 71000000000, TotalRaceTime = 3200000000000 };
            CarInRace cir8 = new CarInRace { CarId = car1.Id, RaceId = race3.Id, Race = race3, StartPosition = 1, EndPosition = 2, BestLap = 31000000000, TotalRaceTime = 1500000000000 };
            CarInRace cir9 = new CarInRace { CarId = car2.Id, RaceId = race3.Id, Race = race3, StartPosition = 2, EndPosition = 3, BestLap = 32000000000, TotalRaceTime = 7100000000000 };
            CarInRace cir10 = new CarInRace { CarId = car3.Id, RaceId = race3.Id, Race = race3, StartPosition = 4, EndPosition = 5, BestLap = 33000000000, TotalRaceTime = 9900000000000 };
            CarInRace cir11 = new CarInRace { CarId = car4.Id, RaceId = race3.Id, Race = race3, StartPosition = 5, EndPosition = 1, BestLap = 34000000000, TotalRaceTime = 20000000000000 };
            CarInRace cir12 = new CarInRace { CarId = car5.Id, RaceId = race3.Id, Race = race3, StartPosition = 3, EndPosition = 4, BestLap = 35000000000, TotalRaceTime = 11000000000000 };
            CarInRace cir13 = new CarInRace { CarId = car1.Id, RaceId = race4.Id, Race = race4, StartPosition = 1, EndPosition = 4, BestLap = 69000000000, TotalRaceTime = 550000000000 };
            CarInRace cir14 = new CarInRace { CarId = car2.Id, RaceId = race4.Id, Race = race4, StartPosition = 4, EndPosition = 2, BestLap = 133000000000, TotalRaceTime = 851000000000 };
            CarInRace cir15 = new CarInRace { CarId = car3.Id, RaceId = race4.Id, Race = race4, StartPosition = 3, EndPosition = 5, BestLap = 120000000000, TotalRaceTime = 921300000000 };
            CarInRace cir16 = new CarInRace { CarId = car4.Id, RaceId = race4.Id, Race = race4, StartPosition = 5, EndPosition = 3, BestLap = 52000000000, TotalRaceTime = 12300000000000 };
            CarInRace cir17 = new CarInRace { CarId = car5.Id, RaceId = race4.Id, Race = race4, StartPosition = 2, EndPosition = 1, BestLap = 50000000000, TotalRaceTime = 5000000000000 };
            CarInRace cir18 = new CarInRace { CarId = car5.Id, RaceId = race5.Id, Race = race5, StartPosition = 1, EndPosition = 1, BestLap = 52500000000, TotalRaceTime = 800000000000 };
            CarInRace cir19 = new CarInRace { CarId = car3.Id, RaceId = race6.Id, Race = race6, StartPosition = 2, EndPosition = 1, BestLap = 99000000000, TotalRaceTime = 250000000000 };
            CarInRace cir20 = new CarInRace { CarId = car4.Id, RaceId = race6.Id, Race = race6, StartPosition = 1, EndPosition = 2, BestLap = 96000000000, TotalRaceTime = 320000000000 };
            var cirs = new[] { cir1, cir2, cir3, cir4, cir5, cir6, cir7, cir8, cir9, cir10, cir11, cir12, cir13, cir14, cir15, cir16, cir17, cir18, cir19, cir20, };
            CarsInRaces.AddRange(cirs);


            SaveChanges();
        }

        public static DbContextOptions<SlotCarContext> GetInMemoryDbOptions(string dbName)
        {
            var builder = new DbContextOptionsBuilder<SlotCarContext>().UseInMemoryDatabase(databaseName: dbName);
            return builder.Options;

        }

    }
}
