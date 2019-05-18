using System;

namespace algorithms.budget
{
    public interface IBudget
    {
         MoneyPot[] MoneyPots { get; set; }
         void CreateMoneyPot();
         void DeleteMoneyPot(Guid id);
         void UpdateMoneyPot(Guid id);
    }
}