﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace Calendar.Droid
{
    [Activity(Label = "Calendar", Icon = "@drawable/icon", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            Forms.SetTitleBarVisibility(AndroidTitleBarVisibility.Never);
            LoadApplication(new App());
        }
    }
}

