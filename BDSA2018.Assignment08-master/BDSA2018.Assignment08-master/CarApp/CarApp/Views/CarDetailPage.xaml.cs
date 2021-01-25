using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarApp.ViewModels;
using BDSA2018.Assignment08.Shared;

namespace CarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarDetailPage : ContentPage
    {
        private readonly CarDetailViewModel _viewModel;
        private readonly CarDTO _car;

        public CarDetailPage(CarDTO car)
        {
            InitializeComponent();

            BindingContext = _viewModel = DependencyService.Resolve<CarDetailViewModel>();

           // _viewModel.Navigation = Navigation;

            _car = car;
            Title = _car.Name;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.Init(_car);
        }

    }
}