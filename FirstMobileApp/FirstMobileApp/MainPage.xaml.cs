using FirstMobileApp.Resources;
using System;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        private int _red = 0;
        private int _green = 0;
        private int _blue = 0;

       
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Bowview.BackgroundColor = Color.FromRgb(_red,_green,_blue);
            RedSlider.Value = _red;
            GreenSlider.Value = _green;
            BlueSlider.Value = _blue;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Settings());
        }

        private void BlueSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _blue = Convert.ToInt32(Math.Floor(e.NewValue));
            BlueLabel.Text = _blue.ToString();
            Bowview.BackgroundColor = Color.FromRgb(_red, _green, _blue);
        }

        private void GreenSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _green = Convert.ToInt32(Math.Floor(e.NewValue));
            GreenLabel.Text = _green.ToString();
            Bowview.BackgroundColor = Color.FromRgb(_red, _green, _blue);
        }

        private void RedSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            _red = Convert.ToInt32(Math.Floor(e.NewValue));
            RedLabel.Text = _red.ToString();
            Bowview.BackgroundColor = Color.FromRgb(_red, _green, _blue);
        }
    }
}
