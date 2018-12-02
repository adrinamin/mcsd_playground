namespace TipCalc.Core.Services
{
    class CalculationService : ICalculationService
    {
        public double TipAmount(double subTotal, int generosity)
        {
            return subTotal * generosity / 100.0;
        }
    }
}
