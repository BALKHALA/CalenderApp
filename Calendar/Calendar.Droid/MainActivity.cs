using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Calendar.Droid
{
    [Activity(Label = "Calendar", Icon = "@drawable/icon", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.Forms.Forms.SetTitleBarVisibility(Xamarin.Forms.AndroidTitleBarVisibility.Never);
            LoadApplication(new App());
        }
    }
}

