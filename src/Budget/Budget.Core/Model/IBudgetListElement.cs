namespace Budget.Core.Model
{
    public interface IBudgetListElement
    {
        string BudgetName { get; set; }
        int CurrentAmount { get; set; }
    }
}
