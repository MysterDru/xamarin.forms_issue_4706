
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace page_crash.Droid
{
    [Application(Label = "page_crash_test")]
    public class MainApplication : Android.App.Application
    {
        readonly string TAG = nameof(MainApplication);

        public App FormsApplication { get; private set; }

        protected MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            Log.Info(TAG, "Entered MainApplication.OnCreate()");

            base.OnCreate();

            Forms.Init(this, null);//, savedInstanceState);
            FormsApplication = new App();
        }
    }
}
