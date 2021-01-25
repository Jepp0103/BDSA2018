using BDSA2018.Assignment08.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2018.Assignment08.Models
{
    public interface ICarRepository
    {
        Task<CarDTO> CreateAsync(CarCreateDTO car);

        Task<CarDTO> FindAsync(int carId);

        Task<byte[]> FindImageAsync(int carId);

        IQueryable<CarDTO> Read();

        Task<bool> UpdateAsync(CarUpdateDTO car);

        Task<bool> DeleteAsync(int carId);
    }
}
