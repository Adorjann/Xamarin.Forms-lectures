using FirstMobileApp.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        
        private  MainPage _mainPage;
        
        public Settings(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
        }

        protected override void OnAppearing()
        {
            if (_mainPage.IsDark)
            {
                SwitchButton.Toggled -= SwitchButton_Toggled;
                SwitchButton.IsToggled = true;
                SwitchButton.Toggled += SwitchButton_Toggled;
            }
        }

        private void SwitchButton_Toggled(object sender, ToggledEventArgs e)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();

            if (_mainPage.IsDark)
            {
                mergedDictionaries.Add(new Light());
                _mainPage.IsDark = false;
            }
            else
            {
                mergedDictionaries.Add(new Dark());
                _mainPage.IsDark = true;
            }
        }
    }
}