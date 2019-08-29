using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DataExample.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityDisplay : ContentPage
    {
        //Local ID store for the Activities we are clicking on
        private int Id { get; set; }
        //Local Class Object store for the Activities we are clicking on
        private Activities SelectedActivities { get; set; }

        public ActivityDisplay(int id)
        {
            InitializeComponent();
            //takes the Activities ID passed from the constructor and stores it locally
            Id = id;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Connect to the database
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Gets the Activities object from the table using its ID
            SelectedActivities = conn.Query<Activities>("select * from Activities where Id = " + Id)[0];

            //Pass the Activities object to the XAML
            BindingContext = SelectedActivities;
            conn.Dispose();


        }
    }
}