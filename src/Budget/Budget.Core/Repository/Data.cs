using Budget.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.Core.Repository
{
    class Data
    {
        public IEnumerable<BudgetListElement> CreateBudgetList()
        {
            var budgetList = new List<BudgetListElement>();
            budgetList.Add(new BudgetListElement());
            return budgetList;
        }
    }
}
