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
    public partial class MerchandiserList : ContentPage
    {
        public MerchandiserList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SendDbListToXaml();
        }

        private async void Merchandiser_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            //take the currently clicked on merchant
            Merchandiser selectedMerchandiser = MerchandiserListView.SelectedItem as Merchandiser;
            //Sends the currently clicked on merchant to the display page
            await Navigation.PushAsync(new MerchandiserDisplay(selectedMerchandiser.Id));
        }

        private void SendDbListToXaml()
        {
            //DB Connection
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Sends the Merchants LIST from the DB to the XAML list to display
            MerchandiserListView.ItemsSource = conn.Table<Merchandiser>();
            //Close DB Connection
            conn.Dispose();
        }
    }
}