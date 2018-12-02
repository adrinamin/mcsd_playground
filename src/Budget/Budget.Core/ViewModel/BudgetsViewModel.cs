using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Budget.Core.ViewModel
{
    class BudgetsViewModel : MvxViewModel
    {
        private bool _isListEmpty;

        public BudgetsViewModel()
        {

        }

        public async  override Task Initialize()
        {
            await base.Initialize();
            _isListEmpty = false; 

        }

        public bool IsListEmpty {
            get => _isListEmpty;
            set
            {
                _isListEmpty = value;
                //RaisePropertyChanged(() => IsListEmpty);
            }
        }

    }
}
