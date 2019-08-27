using System;
using DataExample.DataModel;
using Xamarin.Forms;

namespace DataExample.GlobalMethods
{
    public class BindingObject
    {
        //Global stuff
        public string Font1 { get; set; }
        public string Font2{ get; set; }
        public string Font3 { get; set; }
        public string FontSmall { get; set; }
        public string FontMed { get; set; }
        public string FontLarge { get; set; }
        public string ColorTx1 { get; set; }
        public string ColorTx2 { get; set; }
        public string ColorTx3 { get; set; }
        public string ColorBg1 { get; set; }
        public string ColorBg2 { get; set; }
        public string ColorBg3 { get; set; }
        public string ColorFg1 { get; set; }
        public string ColorFg2 { get; set; }
        public string ColorFg3 { get; set; }


        //Database stuff
        public Client MyClient { get; set; } = null;
        public Merchandiser MyMerchandiser { get; set; } = null;
        public Ticket MyTicket { get; set; } = null;
    }
    public static class Globals
    {

        public static async void PopAsync_Button(object sender, EventArgs e)
        {
            //Global back button functionality
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
