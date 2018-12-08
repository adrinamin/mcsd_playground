using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Budget.Core.ViewModel
{
    public class BudgetViewModel : MvxViewModel
    {
        public BudgetViewModel()
        {

        }

        public async override Task Initialize()
        {
            await base.Initialize();
        }
    }
}
