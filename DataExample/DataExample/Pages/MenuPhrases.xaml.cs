using DataExample.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPhrases : TabbedPage
	{
		public MenuPhrases ()
		{
			InitializeComponent ();
        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        SendDbListToXaml();
        }

	    private void SendDbListToXaml()
	    {
	        var conn = new SQLite.SQLiteConnection(App.DB_PATH);
	        commonPhrases.ItemsSource = conn.Query<Phrases>("SELECT * FROM Phrases WHERE Type = 3");
	        foodPhrases.ItemsSource = conn.Query<Phrases>("SELECT * FROM Phrases WHERE Type = 2");
	        travelPhrases.ItemsSource = conn.Query<Phrases>("SELECT * FROM Phrases WHERE Type = 1");
            conn.Dispose();
	    }
    }
}