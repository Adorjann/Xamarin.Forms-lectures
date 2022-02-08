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
        private Color _buttonColor;

        public MainPage()
        {
            InitializeComponent();

            this._buttonColor = ColorBoxView.BackgroundColor;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            ColorBoxView.BackgroundColor = Color.Brown;
        }

        private void Button_Released(object sender, EventArgs e)
        {
            ColorBoxView.BackgroundColor = _buttonColor;
        }
    }
}
