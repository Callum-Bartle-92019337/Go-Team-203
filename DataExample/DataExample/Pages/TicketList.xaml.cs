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
	public partial class TicketList : ContentPage
	{
        //Stores some SQL Constants
	    private const string BaseQuery = "select * from Ticket where Completed = ";
	    private const string OrderQuery = " Order By DateDue ASC";
        //The Merchant number that we are, NOT our ID
        public string _merchandiserId;

        public TicketList (string merchandiserId)
		{
			//InitializeComponent ();
            //Sets our local Merchant number to the one we got passed
		    _merchandiserId = merchandiserId;
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        SendDbListToXaml();
            
        }
            private void SendDbListToXaml()
	    {
	        //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);

	        if (_merchandiserId != "Supervisor")
            //Display tickets based on our merchant number
	        {
	            //Sends the unfinished Tickets LIST from the DB to the XAML list to display
                unfinishedTicketsList.ItemsSource = conn.Query<Ticket>(BaseQuery + "0 and Merchandiser = " + _merchandiserId + OrderQuery);
	            //Sends the finished Tickets LIST from the DB to the XAML list to display
                finishedTicketsList.ItemsSource = conn.Query<Ticket>(BaseQuery + "1 and Merchandiser = " + _merchandiserId + OrderQuery);
	        }
	        else
            //If we are the Supervisor display all tickets
            {
                //Sends the unfinished Tickets LIST from the DB to the XAML list to display
                unfinishedTicketsList.ItemsSource = conn.Query<Ticket>(BaseQuery + "0" + OrderQuery);
	            //Sends the finished Tickets LIST from the DB to the XAML list to display
                finishedTicketsList.ItemsSource = conn.Query<Ticket>(BaseQuery + "1" + OrderQuery);
	        }
	        //Close connection
	        conn.Dispose();
        }

        private async void TicketsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //take the currently selected unfinished ticket
            Ticket selectedTicket = unfinishedTicketsList.SelectedItem as Ticket;
            //Sends the currently unfinished tickets ID to the display page
            await Navigation.PushAsync(new TicketDisplay(selectedTicket.Id));

        }

	    private async void TicketsListViewFinished_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        //take the currently selected finished ticket
            Ticket selectedTicket = finishedTicketsList.SelectedItem as Ticket;
	        //Sends the currently finished tickets ID to the display page
            await Navigation.PushAsync(new TicketDisplay(selectedTicket.Id));

	    }

        private async void Add_Clicked(object sender, EventArgs e)
	    {
            //Simple Navigation
	        await Navigation.PushAsync(new TicketAdd());
	    }
    }
}