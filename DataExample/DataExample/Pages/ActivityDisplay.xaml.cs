using DataExample.DataModel;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityDisplay : ContentPage
    {
        public ActivityDisplay(int passedId)
        {
            InitializeComponent();
            //takes the Activities ID passed from the constructor and stores it locally
            LocalId = passedId;
        }

        //Local ID store for the Activities we are clicking on
        private int LocalId { get; }

        //Local Class Object store for the Activities we are clicking on
        private Activities SelectedActivities { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Connect to the database
            var conn = new SQLiteConnection(App.dbPath);
            //Gets the Activities object from the table using its ID
            SelectedActivities = conn.Query<Activities>("select * from Activities where Id = " + LocalId)[0];

            //Pass the Activities object to the XAML
            BindingContext = SelectedActivities;
            conn.Dispose();
        }
    }
}