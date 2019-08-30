using DataExample.DataModel;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPhrases : TabbedPage
    {
        public MenuPhrases()
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
            var conn = new SQLiteConnection(App.dbPath);
            CommonPhrases.ItemsSource = conn.Query<Phrases>("SELECT * FROM Phrases WHERE Type = 3");
            FoodPhrases.ItemsSource = conn.Query<Phrases>("SELECT * FROM Phrases WHERE Type = 2");
            TravelPhrases.ItemsSource = conn.Query<Phrases>("SELECT * FROM Phrases WHERE Type = 1");
            conn.Dispose();
        }
    }
}