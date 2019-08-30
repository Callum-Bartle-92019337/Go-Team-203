using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Environment = System.Environment;

//Important

namespace DataExample.Droid
{
    [Activity(Label = "DataExample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //Important Remember
            var fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(fileLocation, "DatabaseProject.sqlite");
            base.OnCreate(savedInstanceState);
            Forms.Init(this, savedInstanceState);

            //Pass constructor
            LoadApplication(new App(dbPath));
        }
    }
}