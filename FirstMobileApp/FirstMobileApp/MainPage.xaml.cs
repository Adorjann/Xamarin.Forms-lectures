using FirstMobileApp.Resources;
using System;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        private bool _isDark = false;
        public MainPage()
        {
            InitializeComponent();
        }

        public bool IsDark { get => _isDark; set => _isDark = value; }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings(this));
        }

    }
}
