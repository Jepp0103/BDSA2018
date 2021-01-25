using BDSA2018.Assignment08.Entities;
using BDSA2018.Assignment08.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2018.Assignment08.Models
{
    public class CarRepository : ICarRepository
    {
        private readonly ISlotCarContext _context;

        public CarRepository(ISlotCarContext context)
        {
            _context = context;
        }

        public async Task<CarDTO> CreateAsync(CarCreateDTO car)
        {
            var entity = new Car
            {
                Name = car.Name,
                Driver = car.Driver,
                Image = car.Image
            };

            _context.Cars.Add(entity);

            await _context.SaveChangesAsync();

            return new CarDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Driver = entity.Driver
            };
        }

        public async Task<CarDTO> FindAsync(int carId)
        {
            var cars = from t in _context.Cars
                         where t.Id == carId
                         select new CarDTO
                         {
                             Id = t.Id,
                             Name = t.Name,
                             Driver = t.Driver
                         };

            return await cars.FirstOrDefaultAsync();
        }

        public async Task<byte[]> FindImageAsync(int carId)
        {
            var cars = from t in _context.Cars
                       where t.Id == carId
                       select t.Image;

            return await cars.FirstOrDefaultAsync();
        }

        public IQueryable<CarDTO> Read()
        {
           return from t in _context.Cars
                  select new CarDTO
                  {
                      Id = t.Id,
                      Name = t.Name,
                      Driver = t.Driver
                  };
        }

        public async Task<bool> UpdateAsync(CarUpdateDTO car)
        {
            var entity = await _context.Cars.FindAsync(car.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = car.Name;
            entity.Driver = car.Driver;
            entity.Image = car.Image;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int carId)
        {
            var car = await _context.Cars.FindAsync(carId);

            if (car == null)
            {
                return false;
            }

            _context.Cars.Remove(car);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
