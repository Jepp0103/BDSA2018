using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using CarApp.Models;
using BDSA2018.Assignment08.Shared;

namespace CarApp.ViewModels
{
    public class CarViewModel : BaseViewModel
    {
            private readonly ICarRepository _repository;

            public ObservableCollection<CarDTO> Cars { get; set; }

            public Command LoadCommand { get; set; }

            public CarViewModel(ICarRepository repository)
            {
                _repository = repository;

                Title = "Cars";
                Cars = new ObservableCollection<CarDTO>();

                LoadCommand = new Command(async () => await ExecuteLoadCommand());
            }

            private async Task ExecuteLoadCommand()
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                try
                {
                    Cars.Clear();

                var cars = await _repository.ReadAsync();

                    foreach (var car in cars)
                    {
                        Cars.Add(car);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }