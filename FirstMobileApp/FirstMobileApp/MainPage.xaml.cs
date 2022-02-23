using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage(1));
        }
    }
}
