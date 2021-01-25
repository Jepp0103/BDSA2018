using BDSA2018.Assignment08.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApp.Models
{
    public interface ICarRepository
    {
        Task<CarDTO> CreateAsync(CarCreateDTO car);

        Task<CarDTO> FindAsync(int carId);

        Task<byte[]> GetByteArrayOfImageAsync(int carId);

        Task<bool> UpdateAsync(CarUpdateDTO car);

        Task<bool> DeleteAsync(int carId);
        Task<IEnumerable<CarDTO>> ReadAsync();

    }
}
