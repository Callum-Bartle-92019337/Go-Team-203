using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuHome : ContentPage
    {
        //Setup for admin buttons
        private bool Admin1 { get; set; }
        private bool Admin2 { get; set; }

        public MenuHome()
        {
            InitializeComponent();
            //Setup for admin buttons
            Admin1 = false;
            Admin2 = false;
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
        }


        private void Admin2_OnClicked(object sender, EventArgs e)
        {
            Admin2 = true;
        }

        private void Admin1_OnReleased(object sender, EventArgs e)
        {
            ButtonChecker();
            Admin1 = false;
            Admin2 = false;
        }

        private void Admin2_OnReleased(object sender, EventArgs e)
        {
            ButtonChecker();
            Admin1 = false;
            Admin2 = false;
        }
        
        private void ButtonChecker()
        {
            //If admin buttons are both released go to ADMIN
            if (Admin1 && Admin2)
            {
                Admin1 = false;
                Admin2 = false;
                Navigation.PushAsync(new MenuAdmin());
            }
        }
    }
}