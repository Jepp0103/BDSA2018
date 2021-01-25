using System;
using System.IO;
using System.Threading.Tasks;
using BDSA2018.Assignment08.Shared;
using CarApp.Models;
using Xamarin.Forms;

namespace CarApp.ViewModels
{
    public class CarDetailViewModel : BaseViewModel
    {
        private readonly ICarRepository _repository;

        private int _carId;
        public int CarId
        {
            get => _carId;
            set => SetProperty(ref _carId, value);
        }

        private string _carName;
        public string CarName
        {
            get => _carName;
            set => SetProperty(ref _carName, value);
        }

        private string _carDriver;
        public string CarDriver
        {
            get => _carDriver;
            set => SetProperty(ref _carDriver, value);
        }

        private ImageSource _carImage;
        public ImageSource CarImage
        {
            get => _carImage;
           set => SetProperty(ref _carImage, value);
      }

        public CarDetailViewModel(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task Init(CarDTO car)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            CarId = car.Id;
            CarName = car.Name;
            CarDriver = car.Driver;

            // I'm not sure that this is the correct way to do it.
            CarImage = await GetImage(car.Id);

            IsBusy = false;
        }

        // Load image of car async
        private async Task<ImageSource> GetImage(int carId)
        {
            var ConvertToBytes = await _repository.GetByteArrayOfImageAsync(carId);
            return ImageSource.FromStream(() => new MemoryStream(ConvertToBytes));
        }

    }
}
    

