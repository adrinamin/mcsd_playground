using BudgetPlannerConsole.BudgetHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerConsole.AppOptionsHandling
{
    interface ICreateBudgetOption
    {
        Budget IntializeBudget();
        void ChangeBudget();
        void SetBudgetName(string name);
        void SetBudgetAmount(double amount);
    }
}
