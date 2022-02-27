using FirstMobileApp.DataAccess;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMobileApp
{
    public partial class App : Application
    {
        internal static readonly NotesRepository NotesRepository
            = new NotesRepository();

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
    }
}
