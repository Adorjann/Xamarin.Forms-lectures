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
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            //DisplayAlert("Alert title", "alert message", "allert cancel");
            DisplayPromptAsync("prompt title","prompt message","ok","cancel");
            
        }
    }
}