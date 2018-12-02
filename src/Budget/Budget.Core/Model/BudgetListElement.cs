using System;

namespace Budget.Core.Model
{
    class BudgetListElement : IBudgetListElement
    {
        public string BudgetName { get; set; }
        public int CurrentAmount { get; set; }
    }
}
