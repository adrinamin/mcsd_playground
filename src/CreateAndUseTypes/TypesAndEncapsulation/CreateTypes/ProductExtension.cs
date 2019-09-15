using TypesAndEncapsulation.CreateTypes;

namespace TypesAndEncapsulation
{
    public static class ProductExtension
    {
        public static double Discount(this Product product)
        {
            return product.Price * 0.9;
        }
    }
}