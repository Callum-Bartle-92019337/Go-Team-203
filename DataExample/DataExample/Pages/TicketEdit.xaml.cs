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
	public partial class TicketEdit : ContentPage
	{
        //Local copy of the edit ID
	    private int TicketIDtoEdit { get; set; }

	    //Local copy of the edit Class Object
        private Ticket TicketObjectToEdit { get; set; }

        public TicketEdit (int ticketIDtoEdit)
		{
			InitializeComponent ();

            //Gets the local ID passed from the constructor
		    TicketIDtoEdit = ticketIDtoEdit;
	    }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

            //Gets the class object from the DB and passes it to the XAML
	        var conn = new SQLite.SQLiteConnection(App.DB_PATH);
	        TicketObjectToEdit = conn.Query<Ticket>("select * from Ticket where Id = " + TicketIDtoEdit)[0];
	        BindingContext = TicketObjectToEdit;
	        //Close connection
	        conn.Dispose();
        }

        private async void Edit_OnClicked(object sender, EventArgs e)
        {
            //Create a new Ticket class object based on the form
            Ticket ticket = new Ticket()
            {
                Id = TicketIDtoEdit,
                Notes = NotesEntry.Text,
                Merchandiser = MerchandiserEntry.Text,
                Date = TicketObjectToEdit.Date,
                DateDue = DueEntry.Date,
                TimeTaken = TicketObjectToEdit.TimeTaken
            };

            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);

            //Create tables
            conn.CreateTable<Ticket>();

            //Insert row
            if (conn.InsertOrReplace(ticket) > 0)
            {
                await DisplayAlert("Success", "", "OK");
            }
            else
            {
                await DisplayAlert("Failed", "", "OK");
            }

            //Close connection
            conn.Dispose();

            //Delete this page from the stack
            await Navigation.PopAsync();
        }

        private void Back_Button(object sender, EventArgs e)
        {
            //calls the global back button
            GlobalMethods.Globals.PopAsync_Button(sender, e);
        }
    }
}