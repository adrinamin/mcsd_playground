using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TipCalc.Core.ViewModel;

namespace TipCalc.Droid.Views
{
    [Activity(Label = "Tip Calculator")]
    class TipView : MvxActivity<TipViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TipView);
        }
    }
}