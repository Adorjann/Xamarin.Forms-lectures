using FirstMobileApp.DataAccess;
using FirstMobileApp.Services;
using FirstMobileApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class App : Application
    {
        private static IServiceProvider _serviceProvider;
        private static ViewModelLocator _viewModelLocator;

        public App()
        {
            InitializeComponent();

            SetupService();
            MainPage = new NavigationPage(new MainPage { BindingContext = Locator.MainViewModel });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static ViewModelLocator Locator => _viewModelLocator ?? (_viewModelLocator = new ViewModelLocator(_serviceProvider));

        private void SetupService()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<NoteEditorViewModel>();
            serviceCollection.AddSingleton<INotesRepository, NotesRepository>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}