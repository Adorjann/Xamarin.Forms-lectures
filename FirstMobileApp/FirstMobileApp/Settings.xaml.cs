using FirstMobileApp.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
                
        public Settings()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //if (_mainPage.IsDark)
            {
                //SwitchButton.Toggled -= SwitchButton_Toggled;
                //SwitchButton.IsToggled = true;
                //SwitchButton.Toggled += SwitchButton_Toggled;
            }
        }

        private void SwitchButton_Toggled(object sender, ToggledEventArgs e)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();

                mergedDictionaries.Add(new Dark());
        }
    }
}