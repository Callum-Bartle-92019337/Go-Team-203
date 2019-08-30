using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExample.DataModel;
using DataExample.GlobalMethods;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataExample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActivityAdd : ContentPage
	{
		public ActivityAdd ()
		{
			InitializeComponent ();
        }

	    //When we click the finalize button
        private async void Add_OnClicked(object sender, EventArgs e)
        {
            //Create a new Activities class object based on the form
            Activities activity = new Activities()
            {
                Title = TitleEntry.Text,
	            Content = ContentEntry.Text,
	            Photo = PhotoEntry.Text
            };
            //Insert the new Class
            Globals.InsertIntoTable(activity, this);
            //Delete this page from the navigation stack
            await Navigation.PopAsync();
	    }

	    private async void Back_Button(object sender, EventArgs e)
        {
            //back button
            await Navigation.PopAsync();
        }
	}
}