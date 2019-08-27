using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DataExample.DataModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DataExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketDisplay : ContentPage
    {
        //Local ID store for the ticket we are clicking on
        private int TicketId { get; set; }
        //Local Class Object store for the ticket we are clicking on
        private Ticket SelectedTicket { get; set; }
        //Is this ticket getting deleted?
        private bool Deletion { get; set; } = false;

        //Timer stuff
        private bool TimeRunning { get; set; }
        private int SecondInt { get; set; }
        private int MinuteInt { get; set; }
        private string SecondString { get; set; }
        private string MinuteString { get; set; }

        public TicketDisplay(int ticketId)
        {
            InitializeComponent();
            //takes the ticket ID passed from the constructor and stores it locally
            TicketId = ticketId;
            //Turns any rouge timers off
            TimeRunning = false;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Connect to the database
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Gets the ticket object from the table using its ID
            SelectedTicket = conn.Query<Ticket>("select * from Ticket where Id = " + TicketId)[0];

            //Pass the ticket object to the XAML
            BindingContext = SelectedTicket;

            //Timer stuff
            var t = SelectedTicket.TimeTaken;
            SecondInt = t % 60;
            MinuteInt = (t- SecondInt) / 60;

            SecondString = SecondInt < 10 ? "0" + SecondInt : "" + SecondInt;
            MinuteString = MinuteInt < 10 ? "0" + MinuteInt : "" + MinuteInt;
            //Sets the timer label to the value from data
            timerLabel.Text = MinuteString + ":" + SecondString;
            timeTakenLabel.Text = "Finished in m" + timerLabel.Text+"s";

            //Hides the timer buttons if the ticket is complete
            buttonContainer.IsVisible = !SelectedTicket.Completed;
            //Shows the time taken if the ticket is complete
            timeTakenLabel.IsVisible = SelectedTicket.Completed;
            //Close connection
            conn.Dispose();


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            TimerStopAndSave();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            //Check if we want to delete the ticket
            bool answer = await DisplayAlert("Ticket: " + SelectedTicket.Id, "Delete Ticket?", "DELETE", "Cancel");
            //If yes, delete ticket logic
            if (answer)
            {
                //Mark for deletion, Prevents the timer saving it from deletion in OnDisappearing()
                Deletion = true;
                //Connect to the database
                var conn = new SQLite.SQLiteConnection(App.DB_PATH);
                //Remove the ticket from the table
                conn.Delete<Ticket>(SelectedTicket.Id);
                //Close connection
                conn.Dispose();
                //Back button logic
                GlobalMethods.Globals.PopAsync_Button(sender, e);
            }
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            //Go to the edit ticket page and pass the ticket ID
            await Navigation.PushAsync(new TicketEdit(SelectedTicket.Id));
        }

        private async void CompleteButton_OnClicked(object sender, EventArgs e)
        {
            //Check if we want to complete the ticket
            bool answer = await DisplayAlert("Ticket: " + SelectedTicket.Id, "Mark complete?", "CONFIRM", "Cancel");
            //If yes, complete ticket logic
            if (answer)
            {
                //Connect to database
                var conn = new SQLite.SQLiteConnection(App.DB_PATH);
                //Mark ticket as complete
                SelectedTicket.Completed = true;
                //Update the data
                conn.InsertOrReplace(SelectedTicket);
                //Close connection
                conn.Dispose();
                //Back button logic
                GlobalMethods.Globals.PopAsync_Button(sender, e);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //if timer is running don't run this logic
            if (TimeRunning) return;

            //Starts the timer
            TimeRunning = true;

            //Starts a timer on the device
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //Exits if the timer is running
                if (!TimeRunning) { return false; }

                //Timer logic
                if (SecondInt < 59)
                {
                    SecondInt++;
                    SecondString = SecondInt < 10 ? "0" + SecondInt : "" + SecondInt;
                }
                else
                {
                    MinuteInt++;
                    SecondInt = 0;
                    SecondString = "00";
                    MinuteString = MinuteInt < 10 ? "0" + MinuteInt : "" + MinuteInt;
                }

                //Updates the timer label
                timerLabel.Text = MinuteString + ":" + SecondString;

                //Makes the timer loop unless false is returned
                return TimeRunning;
            });
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            //Stops the timer
            TimerStopAndSave();
        }

        private void TimerStopAndSave()
        {
            //Turns off timer
            TimeRunning = false;
            //Connects to database
            if (Deletion) return;
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Updates the time taken
            SelectedTicket.TimeTaken = SecondInt + (60 * MinuteInt);
            //Writes over the old value
            conn.InsertOrReplace(SelectedTicket);
            //Close connection
            conn.Dispose();
        }


    }

}