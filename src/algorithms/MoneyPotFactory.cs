namespace algorithms
{
    public class MoneyPotFactory : IMoneyPotFactory
    {
        public MoneyPot CreateMoneyPot(string name, int amount)
        {
            return new MoneyPot{
                PotName = name,
                Amount = amount
            };
        }
    }
}