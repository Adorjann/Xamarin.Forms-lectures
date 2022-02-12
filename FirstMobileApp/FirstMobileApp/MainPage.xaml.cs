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

            FirstLabel.Text = Check1.IsChecked ? "Checked" : "NotChecked";
            SecondLabel.Text = Check2.IsChecked ? "Checked" : "NotChecked";
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            FirstLabel.Text = e.Value ? "Checked" : "Not Checked";
        }

        private void CheckBox_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            SecondLabel.Text = e.Value ? "Checked" : "Not Checked";
        }
    }
}
