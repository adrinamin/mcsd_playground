using System;

namespace algorithms.budget
{
    public class Budget : IBudget
    {
        public MoneyPot[] MoneyPots { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CreateMoneyPot()
        {
            throw new NotImplementedException();
        }

        public void DeleteMoneyPot(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMoneyPot(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}