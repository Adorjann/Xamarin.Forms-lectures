using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        
        public SecondPage(int number)
        {
            InitializeComponent();
            numberLabel.Text = number.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ThirdPage());
        }

        protected override void OnAppearing()
        {
            numberLabel.Text = "Not a number";
        }

        protected override void OnDisappearing()
        {
            //base.OnDisappearing();
        }
    }
}