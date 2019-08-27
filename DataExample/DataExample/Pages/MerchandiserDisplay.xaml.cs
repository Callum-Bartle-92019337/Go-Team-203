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
	public partial class MerchandiserDisplay : ContentPage
	{
        //Local ID store for the Merchandiser we are clicking on
        private int MerchandiserId { get; set; }
        //Local Class Object store for the Merchandiser we are clicking on
        private Merchandiser SelectedMerchandiser { get; set; }

	    public MerchandiserDisplay(int merchandiserId)
	    {
	        InitializeComponent();
            //takes the Merchandiser ID passed from the constructor and stores it locally
            MerchandiserId = merchandiserId;
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

            //Gets the merchandiser Class Object from the DB using its ID
	        var conn = new SQLite.SQLiteConnection(App.DB_PATH);
	        SelectedMerchandiser = conn.Query<Merchandiser>("select * from Merchandiser where Id = " + MerchandiserId)[0];

            //Pass the Merchandiser object to the XAML
            BindingContext = SelectedMerchandiser;

	        //Close connection
            conn.Dispose();
	    }
    }
}