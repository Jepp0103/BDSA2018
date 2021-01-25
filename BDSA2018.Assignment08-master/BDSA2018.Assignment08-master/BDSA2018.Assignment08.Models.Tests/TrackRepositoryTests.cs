using BDSA2018.Assignment08.Entities;
using BDSA2018.Assignment08.Shared;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BDSA2018.Assignment08.Models.Tests
{
    public class TrackRepositoryTests
    {
        [Fact]
        public async Task CreateAsync_given_track_creates_it()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new TrackRepository(context);

                var track = new TrackCreateDTO
                {
                    Name = "name",
                    LengthInMeters = 12.5,
                    MaxCars = 4
                };

                var id = await repository.CreateAsync(track);

                var entity = await context.Tracks.FindAsync(id);
                Assert.Equal("name", entity.Name);
                Assert.Equal(12.5, entity.LengthInMeters);
                Assert.Equal(4, entity.MaxCars);
            }
        }

        [Fact]
        public async Task FindAsync_given_non_existing_id_returns_null()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new TrackRepository(context);

                var track = await repository.FindAsync(42);

                Assert.Null(track);
            }
        }

        [Fact]
        public async Task FindAsync_given_existing_id_returns_mapped_TrackDTO()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Track
                {
                    Name = "name",
                    LengthInMeters = 12.5,
                    BestLapInTicks = TimeSpan.FromSeconds(6.3).Ticks,
                    MaxCars = 4,
                    Races = new[] { new Race { NumberOfLaps = 12 }, new Race { NumberOfLaps = 24 } }
                };

                context.Tracks.Add(entity);
                await context.SaveChangesAsync();
                var id = entity.Id;

                var repository = new TrackRepository(context);

                var track = await repository.FindAsync(id);

                Assert.Equal("name", track.Name);
                Assert.Equal(12.5, track.LengthInMeters);
                Assert.Equal(TimeSpan.FromSeconds(6.3), track.BestLap);
                Assert.Equal(4, track.MaxCars);
                Assert.Equal(2, track.NumberOfRaces);
            }
        }

        [Fact]
        public async Task Read_returns_mapped_TrackDTO()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Track
                {
                    Name = "name",
                    LengthInMeters = 12.5,
                    BestLapInTicks = TimeSpan.FromSeconds(6.3).Ticks,
                    MaxCars = 4,
                    Races = new[] { new Race { NumberOfLaps = 12 }, new Race { NumberOfLaps = 24 } }
                };

                context.Tracks.Add(entity);
                await context.SaveChangesAsync();
                var id = entity.Id;

                var repository = new TrackRepository(context);

                var track = await repository.Read().SingleAsync();

                Assert.Equal(id, track.Id);
                Assert.Equal("name", track.Name);
                Assert.Equal(12.5, track.LengthInMeters);
                Assert.Equal(TimeSpan.FromSeconds(6.3), track.BestLap);
                Assert.Equal(4, track.MaxCars);
                Assert.Equal(2, track.NumberOfRaces);
            }
        }

        [Fact]
        public async Task UpdateAsync_given_track_updates_it()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Track
                {
                    Name = "name",
                    LengthInMeters = 12.5,
                    BestLapInTicks = TimeSpan.FromSeconds(6.3).Ticks,
                    MaxCars = 4,
                };

                context.Tracks.Add(entity);
                await context.SaveChangesAsync();
                var id = entity.Id;

                var repository = new TrackRepository(context);

                var track = new TrackUpdateDTO { Id = id, Name = "new name", LengthInMeters = 4.2, BestLap = null, MaxCars = 2 };

                var updated = await repository.UpdateAsync(track);

                Assert.True(updated);

                var updatedEntity = await context.Tracks.FindAsync(id);

                Assert.Equal("new name", track.Name);
                Assert.Equal(4.2, track.LengthInMeters);
                Assert.Null(track.BestLap);
                Assert.Equal(2, track.MaxCars);
            }
        }

        [Fact]
        public async Task UpdateAsync_given_non_existing_track_returns_false()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new TrackRepository(context);

                var track = new TrackUpdateDTO { Id = 42 };

                var updated = await repository.UpdateAsync(track);

                Assert.False(updated);
            }
        }

        [Fact]
        public async Task DeleteAsync_given_existing_trackId_deletes_it()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Track { Name = "name" };

                context.Tracks.Add(entity);
                await context.SaveChangesAsync();

                var id = entity.Id;

                var repository = new TrackRepository(context);

                var deleted = await repository.DeleteAsync(id);

                Assert.True(deleted);

                var deletedEntity = await context.Tracks.FindAsync(id);

                Assert.Null(deletedEntity);
            }
        }

        [Fact]
        public async Task DeleteAsync_given_non_existing_trackId_returns_false()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new TrackRepository(context);

                var success = await repository.DeleteAsync(42);

                Assert.False(success);
            }
        }

        private async Task<DbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            await connection.OpenAsync();

            return connection;
        }

        private class SlotCarTestContext : SlotCarContext
        {
            public SlotCarTestContext(DbContextOptions<SlotCarContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<CarInRace>().HasKey(c => new { c.CarId, c.RaceId });
            }
        }

        private async Task<ISlotCarContext> CreateContextAsync(DbConnection connection)
        {
            var builder = new DbContextOptionsBuilder<SlotCarContext>()
                              .UseSqlite(connection);

            var context = new SlotCarTestContext(builder.Options);
            await context.Database.EnsureCreatedAsync();

            return context;
        }
    }
}
