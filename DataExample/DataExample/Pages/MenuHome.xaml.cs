using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuHome : ContentPage
    {
        private bool Admin1 { get; set; }
        private bool Admin2 { get; set; }

        public MenuHome()
        {
            InitializeComponent();
        }

        private void Activities_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new ActivityList());
        }

        private void Phrases_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new MenuPhrases());
        }

        private void Admin1_OnClicked(object sender, EventArgs e)
        {
            Admin1 = true;
            ButtonChecker();
        }


        private void Admin2_OnClicked(object sender, EventArgs e)
        {
            Admin2 = true;
            ButtonChecker();
        }

        private void Admin1_OnReleased(object sender, EventArgs e)
        {
            Admin1 = false;
        }

        private void Admin2_OnReleased(object sender, EventArgs e)
        {
            Admin2 = false;
        }
        
        private void ButtonChecker()
        {
            if (Admin1 && Admin2)
            {
            Navigation.PushAsync(new MenuAdmin());
            }
        }
    }
}