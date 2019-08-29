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
    public partial class MenuAdmin : ContentPage
    {
        public MenuAdmin()
        {
            InitializeComponent();
            //DropTables();
            //CreateTables();
            //FillTables();
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
        static void DropTables<T>()
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            conn.DropTable<T>();
            conn.Dispose();
        }

        private static void CreateTables<T>()
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            conn.CreateTable<T>();
            conn.Dispose();
        }

        private static void FillTablesPhr()
        {
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            Phrases phrase;
            //1
            phrase = new Phrases()
            {
                EnglishPhrase = "Where is the nearest train station?",
                JapanesePhrase = "最寄りの鉄道駅はどこですか",
                PhoneticPhrase = "Moyori no tetsudō-eki wa dokodesu ka?",
                Type = 1
            };
            conn.Insert(phrase);
            //2
            phrase = new Phrases()
            {
                EnglishPhrase = "Where is the help desk?",
                JapanesePhrase = "ヘルプデスクはどこですか",
                PhoneticPhrase = "Herupu desuku wa dokodesu ka?",
                Type = 1
            };
            conn.Insert(phrase);
            //3
            phrase = new Phrases()
            {
                EnglishPhrase = "I want to get to the ----- is it this way?",
                JapanesePhrase = "---に行きたいのですが、この方法ですか",
                PhoneticPhrase = "--- ni ikitai nodesuga, kono hōhōdesu ka?",
                Type = 1
            };
            conn.Insert(phrase);
            //4
            phrase = new Phrases()
            {
                EnglishPhrase = "I would like this one",
                JapanesePhrase = "これが欲しい",
                PhoneticPhrase = "Kore ga hoshī",
                Type = 2
            };
            conn.Insert(phrase);
            //5
            phrase = new Phrases()
            {
                EnglishPhrase = "Hello",
                JapanesePhrase = "こんにちは",
                PhoneticPhrase = "Kon'nichiwa",
                Type = 3
            };
            conn.Insert(phrase);
            conn.Dispose();
        }

        private static void FillTablesAct(int i)
        {   // A array of Background images  
            string[] backgrounds = { "background.jpg", "commonBG.jpg", "food.jpg", "logo.png",
                "placeBG.jpg" };
            // Create a Random object  
            Random rand = new Random();
            var conn = new SQLite.SQLiteConnection(App.DB_PATH);
            Activities activity;
            for (int j = 0; j < i; j++)
            {
                activity = new Activities()
                {
                    Title = "Title Text" + rand.Next(100),
                    Content = "Content Text" + rand.Next(100),
                    Photo = backgrounds[rand.Next(backgrounds.Length)]
                };
                conn.Insert(activity);
            }
            conn.Dispose();
        }

        private void Phrase_Button_OnClicked(object sender, EventArgs e)
        {
            DropTables<Phrases>();
            CreateTables<Phrases>();
            FillTablesPhr();
            Navigation.PopAsync();
        }

        private void Act_Button_OnClicked(object sender, EventArgs e)
        {
            DropTables<Activities>();
            CreateTables<Activities>();
            FillTablesAct(4);
            Navigation.PopAsync();
        }
    }
}