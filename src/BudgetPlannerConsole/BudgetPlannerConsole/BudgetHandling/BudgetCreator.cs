namespace BudgetPlannerConsole.BudgetHandling
{
    internal class BudgetCreator : IBudgetCreator
    {
        public Budget CreateBudget()
        {
            return new Budget();
        }
    }
}
