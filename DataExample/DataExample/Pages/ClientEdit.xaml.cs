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
	public partial class ClientEdit : ContentPage
    {

        //Local copy of the edit ID
        private int ClientIDtoEdit { get; set; }

        public ClientEdit(int clientIDtoEdit)
        {
            InitializeComponent();

            //Gets the local ID passed from the constructor
            ClientIDtoEdit = clientIDtoEdit;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Gets the class object from the DB and passes it to the XAML
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            BindingContext = conn.Query<Client>("select * from Client where Id = " + ClientIDtoEdit)[0];
            //Close connection
            conn.Dispose();
        }

        private async void Edit_OnClicked(object sender, EventArgs e)
        {
            //Create a new Client class object based on the form
            Client client = new Client()
            {
                Id = ClientIDtoEdit,
                Name = ClientNameEntry.Text,
                Number = ClientPhoneEntry.Text,
                Address = ClientAddressEntry.Text,
                Email = ClientEmailEntry.Text
            };

            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);

            //Create tables
            conn.CreateTable<Client>();

            //Insert row
            if (conn.InsertOrReplace(client) > 0)
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