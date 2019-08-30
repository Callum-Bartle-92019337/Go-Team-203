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
	public partial class PhraseAdd : ContentPage
	{
		public PhraseAdd()
		{
			InitializeComponent ();
        }

	    //When we click the finalize button
        private async void Add_OnClicked(object sender, EventArgs e)
        {
            //Create a new Activities class object based on the form
            Phrases phrase = new Phrases()
            {
                Type = TypeEntry.SelectedIndex + 1,
                EnglishPhrase = EnglishEntry.Text,
                JapanesePhrase = JapaneseEntry.Text,
                PhoneticPhrase = PhoneticEntry.Text
            };
            //Insert the new Class
            Globals.InsertIntoTable(phrase, this);
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