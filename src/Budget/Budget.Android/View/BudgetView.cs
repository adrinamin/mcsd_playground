using Android.OS;
using Budget.Core.ViewModel;
using MvvmCross.Platforms.Android.Views;

namespace Budget.Android.View
{
    public class BudgetView : MvxActivity<BudgetViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.BudgetView);
        }
    }
}