using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuHome : ContentPage
    {
        public MenuHome()
        {
            InitializeComponent();

            //Creates the tables if they don't already exist
            CreateTables();
        }

        private void Activities_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new MenuSupervisor());
        }

        private void Phrases_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new MenuMerchandiser());
        }

        private async void Reset_Button_OnClicked(object sender, EventArgs e)
        {
            //Hide the menu and show buffering
            menuButtons.IsVisible = false;
            actInd.IsVisible = true;
            actInd.IsRunning = true;
            //Rebuild the data
            await Task.Run(() => DropTables());
            await Task.Run(() => CreateTables());
            await Task.Run(() => FillTables());
            //Return the menu
            actInd.IsVisible = false;
            actInd.IsRunning = false;
            menuButtons.IsVisible = true;
        }

        private static void CreateTables()
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Create tables
            conn.CreateTable<Ticket>();
            conn.CreateTable<Client>();
            conn.CreateTable<Merchandiser>();
            //Close connection
            conn.Dispose();

        }

        private static void DropTables()
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Drop tables
            conn.DropTable<Ticket>();
            conn.DropTable<Client>();
            conn.DropTable<Merchandiser>();
            //Close connection
            conn.Dispose();
        }

        private void FillTables()
        {
            FillTicketsTable();
            FillClientsTable();
            FillMerchandiserTable();
        }

        private static void FillTicketsTable()
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);

            //RNG Generator
            Random rnd = new Random();

            //Create dummy tickets
            var i = 0;
            while (i < 18)
            {
                i++;
                Ticket ticket = new Ticket()
                {
                    Notes = " Yes     Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book." + rnd.Next(3, 40) + "",
                    Merchandiser = "" + rnd.Next(1, 4) + "",
                    Date = System.DateTime.Today,
                    DateDue = System.DateTime.Today.AddDays(rnd.Next(5))
                };
                conn.Insert(ticket);
            }

            //Close connection
            conn.Dispose();

        }

        private static void FillClientsTable()
        {

            //DB Connection
            var conn1 = new SQLite.SQLiteConnection(App.DB_PATH);

            //Create dummy Clients
            Client client = new Client()
            {

                Name = "Client 1",
                Number = "021 555 5555",
                Address = "123 Somewhere",
                Email = "Test@Email.com"
            };
            conn1.Insert(client);

            client = new Client()
            {

                Name = "Client 2",
                Number = "022 555 5555",
                Address = "321 Elsewhere",
                Email = "Forget@About.it"
            };
            conn1.Insert(client);

            client = new Client()
            {

                Name = "Client 3",
                Number = "027 555 5555",
                Address = "453 World",
                Email = "Email@Address.com"
            };
            conn1.Insert(client);

            conn1.Dispose();
        }
        
        private static void FillMerchandiserTable()
        {
            //DB Connection
            var conn1 = new SQLite.SQLiteConnection(App.DB_PATH);

            //Create dummy Merchandisers
            Merchandiser merch = new Merchandiser()
            {

                Name = "Cans For Free",
                Number = "1",
                Address = "47 daddy Lane",
                Email = "a@b.com"
            };
            conn1.Insert(merch);

            merch = new Merchandiser()
            {

                Name = "Fresh Milk",
                Number = "2",
                Address = "12 Paper Drive",
                Email = "b@a.com"
            };
            conn1.Insert(merch);

            merch = new Merchandiser()
            {

                Name = "Boxes For Boxing",
                Number = "3",
                Address = "453 Uptown Drive",
                Email = "c@b.com"
            };
            conn1.Insert(merch);

            conn1.Dispose();
        }
    }
}