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
    public partial class ActivityImageDisplay : ContentPage
    {
        public ActivityImageDisplay()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //CreateTables();
            //FillTables();
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            Activities SelectedActivity = conn.Query<Activities>("SELECT * FROM Activities ORDER BY Id DESC LIMIT 1")[0];
            BindingContext = SelectedActivity;
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
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            Activities activity = new Activities()
            {
                Title = "Title Text",
                Content = "Content Text",
                Photo = "background.jpg"
            };
            conn.Insert(activity);
            conn.Dispose();
        }

        private void New_Button_OnClicked(object sender, EventArgs e)
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            Activities activity = new Activities()
            {
                Title = "Title Text"+new Random().Next(100),
                Content = "Content Text" + new Random().Next(100),
                Photo = "background.jpg"
            };
            conn.Insert(activity);
            conn.Dispose();
            OnAppearing();
        }
    }
}