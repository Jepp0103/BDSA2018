
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarApp.ViewModels;
using BDSA2018.Assignment08.Shared;

namespace CarApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarPage : ContentPage
    {
        private readonly CarViewModel _viewModel;

        public CarPage() 
        {
            InitializeComponent();

            BindingContext = _viewModel = DependencyService.Resolve<CarViewModel>();

           /// _viewModel.Navigation = Navigation;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is CarDTO car))
            {
                return;
            }
            await Navigation.PushAsync(new CarDetailPage(car));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Cars.Count == 0)
            {
                _viewModel.LoadCommand.Execute(null);
            }
        }
    }
}