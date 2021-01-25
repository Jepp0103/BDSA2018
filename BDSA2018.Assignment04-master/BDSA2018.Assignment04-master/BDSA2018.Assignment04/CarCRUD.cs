using BDSA2018.Assignment04.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2018.Assignment04
{
    public class CarCRUD : IDisposable
    {
        private readonly SlotCarContext _context;

        public CarCRUD(SlotCarContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="car"></param>
        /// <returns>The id of the newly created car</returns>
        public int Create(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
            return car.Id;
        }

        public Car FindById(int id)
        {
            return _context.Find<Car>(id);
        }

        public ICollection<Car> All()
        {
            return _context.Cars.ToList();
        }

        public void Update(Car car)
        {
            _context.Entry(FindById(car.Id)).CurrentValues.SetValues(car);
            _context.SaveChanges();
        }

        public void Delete(int carId)
        {
            _context.Remove(FindById(carId));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
