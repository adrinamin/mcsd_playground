using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Core.Model
{
    public interface IBudgetsModel
    {
        IEnumerable<IBudgetListElement> BudgetListElements { get; set; }
    }
}
