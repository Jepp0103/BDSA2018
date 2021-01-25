
using BDSA2018.Assignment08.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarApp.Models
{
    public class CarRepository : ICarRepository 
    {
        private readonly HttpClient _client;

        public CarRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<CarDTO> CreateAsync(CarCreateDTO car)
        {
            var response = await _client.PostAsJsonAsync("api/cars", car);

            return await response.Content.ReadAsAsync<CarDTO>();
        }

        public async Task<bool> DeleteAsync(int carId)
        {
            var response = await _client.DeleteAsync($"api/cars/{carId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<CarDTO> FindAsync(int carid)
        {
            var response = await _client.GetAsync($"api/cars/{carid}");

            return await response.Content.ReadAsAsync<CarDTO>();
        }
        public async Task<byte[]> GetByteArrayOfImageAsync(int carId)
        {
            var result = await _client.GetAsync($"/api/cars/{carId}/image");

            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsByteArrayAsync();

            return null;
        }

        public async Task<IEnumerable<CarDTO>> ReadAsync()
        {
            var response = await _client.GetAsync("api/cars");

            return await response.Content.ReadAsAsync<IEnumerable<CarDTO>>();
        }

        public async Task<bool> UpdateAsync(CarUpdateDTO car)
        {
            var response = await _client.PutAsJsonAsync($"api/cars/{car.Id}", car);

            return response.IsSuccessStatusCode;
        }
    }
}