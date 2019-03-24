using System;

namespace BudgetPlannerConsole.BudgetHandling
{
    public class Budget
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public Budget()
        {
            Console.WriteLine("Budget created");
        }
    }
}
