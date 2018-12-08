using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Budget.Core.ViewModel
{
    class BudgetsViewModel : MvxViewModel
    {
        public BudgetsViewModel()
        {

        }

        public async  override Task Initialize()
        {
            await base.Initialize();
            IsListEmpty = false; 
        }

        public bool IsListEmpty { get; set; }

    }
}
