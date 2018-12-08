using Budget.Core.ViewModel;
using MvvmCross.ViewModels;

namespace Budget.Core
{
     public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<BudgetViewModel>();
        }
    }
}
