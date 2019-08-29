using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataExample.DataModel;
using DataExample.GlobalMethods;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuHome : ContentPage
    {
        //private Ticket SelectedTicket { get; set; }

        public MenuHome()
        {
            InitializeComponent();
            //var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //SelectedTicket = conn.Query<Ticket>("select * from Ticket where Id = " + 1)[0];
            //conn.Dispose();

            //App.G.MyTicket = SelectedTicket;
            BindingContext = App.G;
        }

        private void Activities_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new ActivityList());
        }

        private void Phrases_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new MenuPhrases());
        }

        private void New_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new MenuAdmin());
        }

    }
}