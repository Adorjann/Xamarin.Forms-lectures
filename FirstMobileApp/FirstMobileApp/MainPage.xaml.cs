using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //some comment to test git
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            GestureLabel.Text = "Xamarin";
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Label linkLabela = (Label)sender;
            linkLabela.TextColor = Color.Purple;
            Browser.OpenAsync("Https://google.com");
        }
    }
}
