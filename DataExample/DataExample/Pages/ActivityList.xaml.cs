using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExample.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityList : ContentPage
    {
        public ActivityList()
        {
            InitializeComponent();
            //DropTables();
            //CreateTables();
            //FillTables();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SendDbListToXaml();
        }

        private void SendDbListToXaml()
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            activitiesList.ItemsSource = conn.Query<Activities>("SELECT * FROM Activities");
            //BindingContext = App.G;
            conn.Dispose();
        }

        private static void DropTables()
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            conn.DropTable<Activities>();
            conn.Dispose();
        }

        private static void CreateTables()
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            conn.CreateTable<Activities>();
            conn.Dispose();
        }

        private static void FillTables()
        {   // A array of Background images  
            string[] backgrounds = { "background.jpg", "commonBG.jpg", "food.jpg", "logo.png",
                "placeBG.jpg" };
            // Create a Random object  
            Random rand = new Random();

            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            Activities activity = new Activities()
            {
                Title = "Title Text" + rand.Next(100),
                Content = "Content Text" + rand.Next(100),
                Photo = backgrounds[rand.Next(backgrounds.Length)]
            };
            conn.Insert(activity);
            conn.Dispose();
        }

        //private void New_Button_OnClicked(object sender, EventArgs e)
        //{
        //    FillTables();
        //    var refreshPage = new ActivityList();
        //    Navigation.InsertPageBefore(refreshPage, this);
        //    Navigation.PopAsync();
        //}

        private async void ActivitiesListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //take the currently selected unfinished ticket
            Activities selectedActivities = activitiesList.SelectedItem as Activities;
            //Sends the currently unfinished tickets ID to the display page
            await Navigation.PushAsync(new ActivityDisplay(selectedActivities.Id));
        }
    }
}