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
	public partial class ClientDisplay : ContentPage
    {
        //Local ID store for the Client we are clicking on
        private int ClientId { get; set; }
        //Local Class Object store for the Client we are clicking on
        private Client SelectedClient { get; set; }

        public ClientDisplay(int clientId)
        {
            InitializeComponent();
            //takes the Client ID passed from the constructor and stores it locally
            ClientId = clientId;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Gets the Client Class Object from the DB using its ID
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            SelectedClient = conn.Query<Client>("select * from Client where Id = " + ClientId)[0];

            //Pass the Client object to the XAML
            BindingContext = SelectedClient;

            //Close connection
            conn.Dispose();
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            //Pass the clients ID to the edit page and navigate
            await Navigation.PushAsync(new ClientEdit(SelectedClient.Id));
        }
    }
}