using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarApp.Views;
using Xamarin.Forms.Internals;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using CarApp.Models;
using CarApp.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CarApp
{
    public partial class App : Application
    {
        private static readonly Uri _backendUrl = new Uri("https://localhost:44394"); // URL to ASP.NET Web API

        private readonly Lazy<IServiceProvider> _lazyProvider = new Lazy<IServiceProvider>(() => ConfigureServices());

        public IServiceProvider Container => _lazyProvider.Value;

        public App()
        {
            InitializeComponent();

            DependencyResolver.ResolveUsing(type => Container.GetService(type)); // Allow Xamarin to use IOC Container

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            var handler = new HttpClientHandler();

            // Ignore invalid/non-existing certificate of Web API so HTTPS-connection can be used despite "fake" validation
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
#endif
            services.AddSingleton(_ => new HttpClient(handler) { BaseAddress = _backendUrl });
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<CarViewModel>();
            services.AddScoped<CarDetailViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
