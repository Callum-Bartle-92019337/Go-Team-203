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
            Globals.InsertAllIntoTable(GetActivitiesList(), this);
            await Navigation.PopAsync();
        }

        private List<Activities> GetActivitiesList()
        {
            List<Activities> list = new List<Activities>();
            list.Add(new Activities()
            {
                Title = "Tokyo Skytree",
                Content = "The Tokyo Skytree is a television broadcasting tower and landmark of Tokyo. It is the centerpiece of the Tokyo Skytree Town in the Sumida City Ward, not far away from Asakusa. With a height of 634 meters, it is the tallest structure in Japan and the second tallest in the world at the time of its completion. A large shopping complex with aquarium is located at its base.\r\n\r\nThe highlight of the Tokyo Skytree is its two observation decks which offer spectacular views out over Tokyo. The two enclosed decks are located at heights of 350 and 450 meters respectively, making them the highest observation decks in Japan and some of the highest in the world.",
                Photo = "place1.png"
            });
            list.Add(new Activities()
            {
                Title = "Sensoji Temple",
                Content = "Sensoji Temple in Tokyo\'s proletarian east-end area of Asakusa is one of Tokyo\'s oldest temples, founded in 628. Sensoji is not only one of Tokyo\'s grandest-looking temples, with its big, bold red gate, imposing temple buildings, and five-story pagoda - but it is also one of the most buzzing temples in the metropolis. More than just a temple, Sensoji is a neighborhood in its own right, preserving the feel of old Tokyo. A unique feature is its approximately 250 meter-long Nakamise-dori entrance route lined with hundreds of stalls selling snacks and trinkets to the thousands of visitors that throng the temple.",
                Photo = "place2.png"
            });
            list.Add(new Activities()
            {
                Title = "Sumo",
                Content = "Sumo is a Japanese style of wrestling and Japan\'s national sport. It originated in ancient times as a performance to entertain the Shinto deities. In line with tradition, only men practice the sport professionally in Japan. The rules are simple: the wrestler who first exits the ring or touches the ground with any part of his body besides the soles of his feet loses. Matches take place on an elevated ring (dohyo), which is made of clay and covered in a layer of sand. A contest usually lasts only a few seconds, but in rare cases can take a minute or more. There are no weight restrictions or classes in sumo, meaning that wrestlers can easily find themselves matched off against someone many times their size. As a result, weight gain is an essential part of sumo training.",
                Photo = "place3.png"
            });
            list.Add(new Activities()
            {
                Title = "Shinobazu Pond",
                Content = "The natural pond covers an area of roughly 110,000 square meters and can be divided into three major sections. The first section consists of the lotus pond, the second section is the duck pond, which provides a habitat for ducks and other waterfowl, and the third constitutes a boat pond where visitors can enjoy paddling small boats.",
                Photo = "place4.png"
            });
            list.Add(new Activities()
            {
                Title = "Tokyo Disneyland",
                Content = "Tokyo Disneyland is a theme park based on the films produced by Walt Disney. It was opened in 1983 as the first Disney theme park outside of the United States. Modeled after Disneyland in California and the Magic Kingdom in Florida, Tokyo Disneyland is made up of seven themed lands and features seasonal decorations and parades.",
                Photo = "place5.png"
            });
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
                Type = 1//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Where is the help desk?",
                JapanesePhrase = "ヘルプデスクはどこですか",
                PhoneticPhrase = "Herupu desuku wa dokodesu ka?",
                Type = 1//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "I want to get to the ----- is it this way?",
                JapanesePhrase = "---に行きたいのですが、この方法ですか",
                PhoneticPhrase = "--- ni ikitai nodesuga, kono hōhōdesu ka?",
                Type = 1//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Where are the elevators?",
                JapanesePhrase = "エレベーターはどこですか",
                PhoneticPhrase = "Erebētā wa dokodesu ka?",
                Type = 1//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "I would like this one",
                JapanesePhrase = "これが欲しい",
                PhoneticPhrase = "Kore ga hoshī",
                Type = 2//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "How big is this?",
                JapanesePhrase = "これはどれくらいですか",
                PhoneticPhrase = "Kore wa dorekuraidesu ka?",
                Type = 2//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Where do I pay?",
                JapanesePhrase = "支払いはどこですか",
                PhoneticPhrase = "Shiharai wa dokodesu ka?",
                Type = 2//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Where do I collect my food?",
                JapanesePhrase = "食べ物はどこで集めますか",
                PhoneticPhrase = "Tabemono wa doko de atsumemasu ka?",
                Type = 2//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "How much is this?",
                JapanesePhrase = "これはいくらですか",
                PhoneticPhrase = "Kore wa ikuradesu ka?",
                Type = 2//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Hello",
                JapanesePhrase = "こんにちは",
                PhoneticPhrase = "Kon'nichiwa",
                Type = 3//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Excuse me",
                JapanesePhrase = "すみません",
                PhoneticPhrase = "Sumimasen",
                Type = 3//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Sorry",
                JapanesePhrase = "ごめんなさい",
                PhoneticPhrase = "Gomen\'nasai",
                Type = 3//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Thank you",
                JapanesePhrase = "ありがとうございました",
                PhoneticPhrase = "Arigatōgozaimashita",
                Type = 3//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Goodbye",
                JapanesePhrase = "さようなら",
                PhoneticPhrase = "Sayōnara",
                Type = 3//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "Where is the bathroom please?",
                JapanesePhrase = "トイレはどこですか",
                PhoneticPhrase = "Toire wa dokodesu ka",
                Type = 3//1 Travel, 2 Food, 3 Common
            });
            list.Add(new Phrases()
            {
                EnglishPhrase = "I don’t speak japanese.",
                JapanesePhrase = "私は日本語が話せません",
                PhoneticPhrase = "Watashi wa nihongo ga hanasemasen",
                Type = 3//1 Travel, 2 Food, 3 Common
            });
            return list;
        }
    }
}