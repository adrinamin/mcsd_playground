using System;
using System.Collections.Generic;
using TypesAndEncapsulation.CreateTypes;
using TypesAndEncapsulation.ImplementingDotNetFrameworkInterfaces;
using TypesAndEncapsulation.WorkingWithStrings;

namespace TypesAndEncapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            BuyProductWithDiscount(new Product());
            OrderList();
            SomeBuilder();
        }

        private static void SomeBuilder()
        {
            string[] values = new string[]{"hello", "wow"};
            SomeBuilder builder = new SomeBuilder();
            builder.CreateString(values);
        }

        private static void BuyProductWithDiscount(Product p)
        {
            if (p.Name != null && p.Price != 0.0)
            {
                return;
            }

            p.Name = "oat milk";
            p.Price = 2.00;
            var currentPrice = p.Price;
            var discountPrice = p.Discount();
            currentPrice = discountPrice;
        }

        private static void OrderList()
        {
            List<Order> orders = new List<Order>
            {
                new Order { Created = new DateTime(2012, 12, 1 )},
                new Order { Created = new DateTime(2012, 1, 6 )},
                new Order { Created = new DateTime(2012, 7, 8 )},
                new Order { Created = new DateTime(2012, 2, 20 )},
            };

            orders.Sort();

            foreach (var order in orders)
            {
                Console.WriteLine(order.Created);
            }
        }
    }
}
