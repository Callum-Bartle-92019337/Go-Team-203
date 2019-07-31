using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TicketAdd : ContentPage
	{
		public TicketAdd ()
		{
			InitializeComponent ();
        }

	    //When we click the finalize button
        private async void Add_OnClicked(object sender, EventArgs e)
        {
            //Create a new Ticket class object based on the form
            Ticket ticket = new Ticket()
	        {
	            Notes = NotesEntry.Text,
	            Merchandiser = MerchandiserEntry.Text,
                Date = System.DateTime.Today,
	            DateDue = DueEntry.Date
            };

	        //DB Connection
	        var conn = new SQLite.SQLiteConnection(App.DB_PATH);

            //Insert row and display if Success
            if (conn.Insert(ticket) != 0)
            {await DisplayAlert("Success", "", "OK");}
            else
            {await DisplayAlert("Failed", "", "OK");}

            //Close connection
	        conn.Dispose();

            //Delete this page from the navigation stack
            await Navigation.PopAsync();
	    }

	    private async void Back_Button(object sender, EventArgs e)
        {
            //calls the global back button
            GlobalMethods.Globals.PopAsync_Button(sender, e);
        }
	}
}