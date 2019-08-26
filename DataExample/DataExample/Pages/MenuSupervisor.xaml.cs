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

        private async void Tickets_OnClicked(object sender, EventArgs e)
        {
            //Simple navigation and pass our merchant number "Supervisor" to see all tickets
            await Navigation.PushAsync(new TicketList("Supervisor"));
        }

        private async void Merchandiser_OnClick(object sender, EventArgs e)
        {
            //Simple navigation
            await Navigation.PushAsync(new MerchandiserList());
        }

        private async void Client_OnClick(object sender, EventArgs e)
        {
            //Simple navigation
            await Navigation.PushAsync(new ClientList());
        }
    }
}
