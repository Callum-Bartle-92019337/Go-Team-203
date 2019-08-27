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
    public partial class ClientAdd : ContentPage
    {
        public ClientAdd()
        {
            InitializeComponent();
        }

        //When we click the finalize button
        private async void Add_OnClicked(object sender, EventArgs e)
        {
            //Create a new Client class object based on the form
            Client client = new Client()
            {
                Name = ClientNameEntry.Text,
                Number = ClientPhoneEntry.Text,
                Address = ClientAddressEntry.Text,
                Email = ClientEmailEntry.Text
            };

        //DB Connection
        var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            
            //Insert row
            if (conn.Insert(client) > 0)
            {await DisplayAlert("Success", "", "OK"); }
            else
            {await DisplayAlert("Failed", "", "OK");}

            //Close connection
            conn.Dispose();

            //Delete this page from the navigation stack
            await Navigation.PopAsync();
        }

        private void Back_Button(object sender, EventArgs e)
        {
            //calls the global back button
            GlobalMethods.Globals.PopAsync_Button(sender, e);
        }
    }
}