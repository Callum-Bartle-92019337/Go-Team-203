using System;
using DataExample.GlobalMethods;
using DataExample.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DataExample
{
    public partial class App : Application
    {
        //Local string to store the database path
        public static string DB_PATH = string.Empty;
        public static BindingObject GLOBAL_BINDINGS;

        //Add a new constructor for the database
        public App(string dbPath)
        {
            InitializeComponent();
            DB_PATH = dbPath;
            GLOBAL_BINDINGS = 
                new BindingObject
                {
                    Font1 = "san-serif-medium",
                    Font2 = "Cursive",
                    Font3 = "Impact",
                    FontSmall = "10",
                    FontMed = "14",
                    FontLarge = "24",
                    ColorTx1 = "#FFFFFF", //White
                    ColorTx2 = "#FFFFFF",
                    ColorTx3 = "#FFFFFF",
                    ColorBg1 = "#5992FF", //Blue
                    ColorBg2 = "#FFFFFF",
                    ColorBg3 = "#FFFFFF",
                    ColorFg1 = "#FFFFFF",
                    ColorFg2 = "#FFFFFF",
                    ColorFg3 = "#FFFFFF"
                };

            //Important to make as navigation
            MainPage = new NavigationPage(new MenuHome())
            {
                BarBackgroundColor = Color.FromHex(GLOBAL_BINDINGS.ColorBg1),
                BarTextColor = Color.FromHex(GLOBAL_BINDINGS.ColorTx1),
            };
        }
    }
}
