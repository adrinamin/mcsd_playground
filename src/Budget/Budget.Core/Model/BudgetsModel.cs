using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Core.Model
{
    class BudgetsModel : IBudgetsModel
    {
        public IEnumerable<IBudgetListElement> BudgetListElements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
