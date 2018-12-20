using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Android.Util;

namespace page_crash.Droid
{
    [Activity(Label = "page_crash", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        readonly string TAG = nameof(MainActivity);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Log.Info(TAG, "Entered MainActivity.OnCreate()");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            TrapException();

            var formsApp = (this.Application as MainApplication).FormsApplication;

            LoadApplication(formsApp);
        }

        protected override void OnPause()
        {
            Log.Info(TAG, "Entered MainActivity.OnPause()");

            base.OnPause();
        }

        protected override void OnStop()
        {
            Log.Info(TAG, "Entered MainActivity.OnStop()");

            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Log.Info(TAG, "Entered MainActivity.OnDestroy()");

            base.OnDestroy();
        }

        private void TrapException()
        {
            AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) => OnUnhandledException(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => OnUnhandledException(args.ExceptionObject as Exception);
            TaskScheduler.UnobservedTaskException += (sender, args) => OnUnhandledException(args.Exception);
        }

        private void OnUnhandledException(Exception ex)
        {
            Debugger.Break();
        }
    }
}