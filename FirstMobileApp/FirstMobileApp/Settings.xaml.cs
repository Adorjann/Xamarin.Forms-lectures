using FirstMobileApp.Resources;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

        public Settings()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            if (App.IsDarkTheme)
            {
                SwitchButton.Toggled -= SwitchButton_Toggled;
                SwitchButton.IsToggled = true;
                SwitchButton.Toggled += SwitchButton_Toggled;
            }
        }

        private void SwitchButton_Toggled(object sender, ToggledEventArgs e)
        {
            
            mergedDictionaries.Clear();

            if (!App.IsDarkTheme)
            {
                mergedDictionaries.Add(new Dark());
                App.IsDarkTheme = true; 

                return;
            }
            mergedDictionaries.Add(new Light());
            App.IsDarkTheme = false;
        }
    }
}