using BDSA2018.Assignment08.Entities;
using BDSA2018.Assignment08.Shared;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;

namespace BDSA2018.Assignment08.Models.Tests
{
    public class CarRepositoryTests
    {
        [Fact]
        public async Task CreateAsync_given_car_creates_it()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new CarRepository(context);

                var car = new CarCreateDTO
                {
                    Name = "name",
                    Driver = "driver",
                    Image = new byte[] { 1, 2, 3 }
                };

                var created = await repository.CreateAsync(car);

                var entity = await context.Cars.FindAsync(created.Id);
                Assert.Equal("name", entity.Name);
                Assert.Equal("driver", entity.Driver);
                Assert.Equal(new byte[] { 1, 2, 3 }, entity.Image);
            }
        }

        [Fact]
        public async Task FindAsync_given_non_existing_id_returns_null()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new CarRepository(context);

                var car = await repository.FindAsync(42);

                Assert.Null(car);
            }
        }

        [Fact]
        public async Task FindAsync_given_existing_id_returns_mapped_CarDTO()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Car
                {
                    Name = "name",
                    Driver = "driver",
                    Image = new byte[] { 1, 2, 3 }
                };

                context.Cars.Add(entity);
                await context.SaveChangesAsync();
                var id = entity.Id;

                var repository = new CarRepository(context);

                var car = await repository.FindAsync(id);

                Assert.Equal("name", car.Name);
                Assert.Equal("driver", car.Driver);
            }
        }

        [Fact]
        public async Task FindImageAsync_given_non_existing_id_returns_null()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new CarRepository(context);

                var image = await repository.FindImageAsync(42);

                Assert.Null(image);
            }
        }

        [Fact]
        public async Task FindImageAsync_given_existing_id_returns_image()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Car
                {
                    Name = "name",
                    Driver = "driver",
                    Image = new byte[] { 1, 2, 3 }
                };

                context.Cars.Add(entity);
                await context.SaveChangesAsync();
                var id = entity.Id;

                var repository = new CarRepository(context);

                var image = await repository.FindImageAsync(id);

                Assert.Equal(new byte[] { 1, 2, 3 }, image);
            }
        }

        [Fact]
        public async Task Read_returns_mapped_CarDTO()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Car
                {
                    Name = "name",
                    Driver = "driver"
                };

                context.Cars.Add(entity);
                await context.SaveChangesAsync();
                var id = entity.Id;

                var repository = new CarRepository(context);

                var car = await repository.Read().SingleAsync();

                Assert.Equal(id, car.Id);
                Assert.Equal("name", car.Name);
                Assert.Equal("driver", car.Driver);
            }
        }

        [Fact]
        public async Task UpdateAsync_given_car_updates_it()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Car
                {
                    Name = "name",
                    Driver = "driver",
                    Image = new byte[] { 1, 2, 3 }
                };

                context.Cars.Add(entity);
                await context.SaveChangesAsync();
                var id = entity.Id;

                var repository = new CarRepository(context);

                var car = new CarUpdateDTO
                {
                    Id = id,
                    Name = "new name",
                    Driver = "driver",
                    Image = new byte[] { 1, 2, 3 }
                };

                var updated = await repository.UpdateAsync(car);

                Assert.True(updated);

                var updatedEntity = await context.Cars.FindAsync(id);

                Assert.Equal("new name", car.Name);
                Assert.Equal("driver", car.Driver);
                Assert.Equal(new byte[] { 1, 2, 3 }, car.Image);
            }
        }

        [Fact]
        public async Task UpdateAsync_given_non_existing_car_returns_false()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new CarRepository(context);

                var car = new CarUpdateDTO { Id = 42 };

                var updated = await repository.UpdateAsync(car);

                Assert.False(updated);
            }
        }

        [Fact]
        public async Task DeleteAsync_given_existing_carId_deletes_it()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Car { Name = "name" };

                context.Cars.Add(entity);
                await context.SaveChangesAsync();

                var id = entity.Id;

                var repository = new CarRepository(context);

                var deleted = await repository.DeleteAsync(id);

                Assert.True(deleted);

                var deletedEntity = await context.Cars.FindAsync(id);

                Assert.Null(deletedEntity);
            }
        }

        [Fact]
        public async Task DeleteAsync_given_non_existing_carId_returns_false()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new CarRepository(context);

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
