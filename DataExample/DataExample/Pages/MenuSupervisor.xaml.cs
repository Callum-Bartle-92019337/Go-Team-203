using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExample.Pages;
using Xamarin.Forms;

namespace DataExample
{
    public partial class MenuSupervisor : ContentPage
    {
        public MenuSupervisor()
        {
            InitializeComponent();
        }
        private async void Delete_Clicked(object sender, EventArgs e)
        {
           ////Check if we want to delete the ticket
           // bool answer = await DisplayAlert("Ticket: " + SelectedTicket.Id, "Delete Ticket?", "DELETE", "Cancel");
           // //If yes, delete ticket logic
           // if (answer)
           // {
           //     //Mark for deletion, Prevents the timer saving it from deletion in OnDisappearing()
           //     Deletion = true;
           //     //Connect to the database
           //     var conn = new SQLite.SQLiteConnection(App.DB_PATH);
           //     //Remove  the ticket from the table
           //     conn.Delete<Ticket>(SelectedTicket.Id);
           //     //Close connection
           //     conn.Dispose();
           //     //Back button logic
           //     GlobalMethods.Globals.PopAsync_Button(sender, e);
           // }
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            ////Go to the edit ticket page and pass the ticket ID
            //await Navigation.PushAsync(new TicketEdit(SelectedTicket.Id));
        }
        private async void Add_Clicked(object sender, EventArgs e)
        {
        }
        }
}
