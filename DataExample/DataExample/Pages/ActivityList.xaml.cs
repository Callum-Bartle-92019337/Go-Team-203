using DataExample.DataModel;
using SQLite;
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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SendDbListToXaml();
        }

        private void SendDbListToXaml()
        {
            //Gets the information from the DB and passes it to the xaml
            var conn = new SQLiteConnection(App.dbPath);
            ActivitiesList.ItemsSource = conn.Query<Activities>("SELECT * FROM Activities");
            conn.Dispose();
        }

        private async void ActivitiesListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //take the currently selected Activity
            var selectedActivities = ActivitiesList.SelectedItem as Activities;
            //Sends the Activity ID to the display page
            await Navigation.PushAsync(new ActivityDisplay(selectedActivities.Id));
        }
    }
}