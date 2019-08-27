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
	public partial class ClientList : ContentPage
	{
		public ClientList ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        SendDbListToXaml();
	    }

        private async void Client_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            //take the currently clicked on client
            Client selectedClient = ClientListView.SelectedItem as Client;
            //Sends the currently clicked on client to the display page
            await Navigation.PushAsync(new ClientDisplay(selectedClient.Id));
        }

	    private async void Add_Clicked(object sender, EventArgs e)
	    {
            //Simple Navigation
	        await Navigation.PushAsync(new ClientAdd());
	    }

	    private void SendDbListToXaml()
	    {
	        //DB Connection
	        var conn = new SQLite.SQLiteConnection(App.DB_PATH);
	        //Sends the clients LIST from the DB to the XAML list to display
	        ClientListView.ItemsSource = conn.Table<Client>();
	        //Close DB Connection
	        conn.Dispose();
        }
    }
}