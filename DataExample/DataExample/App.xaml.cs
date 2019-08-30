using DataExample.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace DataExample
{
    public partial class App : Application
    {
        //Local string to store the database path
        public static string dbPath = string.Empty;

        //Add a new constructor for the database
        public App(string fileStoragePath)
        {
            InitializeComponent();
            dbPath = fileStoragePath;

            //Important to make as navigation
            MainPage = new NavigationPage(new MenuHome())
            {
                BarBackgroundColor = Color.FromHex("#5992FF"),
                BarTextColor = Color.FromHex("#FFFFFF")
            };
        }
    }
}