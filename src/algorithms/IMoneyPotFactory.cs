namespace algorithms
{
    public interface IMoneyPotFactory
    {
         MoneyPot CreateMoneyPot(string name, int amount);
    }
}