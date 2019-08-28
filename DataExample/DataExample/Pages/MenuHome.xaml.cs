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

            //App.GLOBAL_BINDINGS.MyTicket = SelectedTicket;
            BindingContext = App.GLOBAL_BINDINGS;
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

        private void New_Button_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            Navigation.PushAsync(new ActivityImageDisplay());
        }

    }
}