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
        private const string Username = "02hero";
        private const string Password = "predavanje3";

        public MainPage()
        {
            InitializeComponent();

            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(UserNameEntry.Text == Username && PasswordEntry.Text == Password)
            {
                InfoLabel.Text = "Uspesan login!";
                InfoLabel.TextColor = Color.Green;
            }
            else
            {
                InfoLabel.Text = "Neuspesan login";
                InfoLabel.TextColor= Color.Red;
            }
        }
    }
}
