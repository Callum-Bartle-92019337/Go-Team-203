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
    public partial class MenuAdmin : ContentPage
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            //Activities SelectedActivity = conn.Query<Activities>("SELECT * FROM Activities ORDER BY Id DESC LIMIT 1")[0];
            //App.G.Activities = SelectedActivity;
            //BindingContext = App.G;
            //conn.Dispose();
        }

        private async void Add_Act_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            await Navigation.PushAsync(new ActivityAdd());
        }

        private async void Add_Phrase_OnClicked(object sender, EventArgs e)
        {
            //Simple Navigation
            await Navigation.PushAsync(new PhraseAdd());
        }

        private async void Refresh_Phrases_OnClicked(object sender, EventArgs e)
        {
            Globals.DropTables<Phrases>();
            Globals.CreateTables<Phrases>();
            Globals.InsertAllIntoTable(GetPhrasesList(), this);
            await Navigation.PopAsync();
        }

        private async void Refresh_Act_OnClicked(object sender, EventArgs e)
        {
            Globals.DropTables<Activities>();
            Globals.CreateTables<Activities>();
            Globals.InsertAllIntoTable(GetActivitiesList(4), this);
            await Navigation.PopAsync();
        }

        private List<Activities> GetActivitiesList(int i)
        {   // A array of Background images  
            string[] backgrounds = { "background.jpg", "commonBG.jpg", "food.jpg", "logo.png",
                "placeBG.jpg" };
            // Create a Random object  
            Random rand = new Random();
            List<Activities> list = new List<Activities>();
            for (int j = 0; j < i; j++)
            {
                list.Add(new Activities()
                {
                    Title = "Title Text" + rand.Next(100),
                    Content = "Content Text" + rand.Next(100),
                    Photo = backgrounds[rand.Next(backgrounds.Length)]
                });
            }

            return list;
        }

        private List<Phrases> GetPhrasesList()
        {
            List<Phrases> list = new List<Phrases>();
            list.Add(new Phrases()
            {
                EnglishPhrase = "Where is the nearest train station?",
                JapanesePhrase = "最寄りの鉄道駅はどこですか",
                PhoneticPhrase = "Moyori no tetsudō-eki wa dokodesu ka?",
                Type = 1
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Where is the help desk?",
                JapanesePhrase = "ヘルプデスクはどこですか",
                PhoneticPhrase = "Herupu desuku wa dokodesu ka?",
                Type = 1
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "I want to get to the ----- is it this way?",
                JapanesePhrase = "---に行きたいのですが、この方法ですか",
                PhoneticPhrase = "--- ni ikitai nodesuga, kono hōhōdesu ka?",
                Type = 1
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "I would like this one",
                JapanesePhrase = "これが欲しい",
                PhoneticPhrase = "Kore ga hoshī",
                Type = 2
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Hello",
                JapanesePhrase = "こんにちは",
                PhoneticPhrase = "Kon'nichiwa",
                Type = 3
            });
            return list;
        }
    }
}