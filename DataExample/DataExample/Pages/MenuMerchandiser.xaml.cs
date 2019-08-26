using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExample.Pages;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuMerchandiser : TabbedPage
	{
		public MenuMerchandiser ()
		{
			InitializeComponent ();
	    }

	    private void Merchandiser1_OnClicked(object sender, EventArgs e)
	    {
            //Simple navigation and pass our merchant number, NOT our ID
	        Navigation.PushAsync(new TicketList("1"));
        }

	    private void Merchandiser2_OnClicked(object sender, EventArgs e)
	    {
	        //Simple navigation and pass our merchant number, NOT our ID
            Navigation.PushAsync(new TicketList("2"));
        }

	    private void Merchandiser3_OnClicked(object sender, EventArgs e)
	    {
	        //Simple navigation and pass our merchant number, NOT our ID
            Navigation.PushAsync(new TicketList("3"));
        }
    }
}