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


        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            SliderValueLabel.Text = e.NewValue.ToString();
        }
    }
}
