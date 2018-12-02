
using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace TipCalc.Droid.Views
{
    [Activity(Label = "My Tip Calc", MainLauncher = true, NoHistory = true)]
    class SplashScreenActivity : MvxSplashScreenActivity
    {
        public SplashScreenActivity()
            : base(Resource.Layout.Splashscreen)
        {
        }
    }
}