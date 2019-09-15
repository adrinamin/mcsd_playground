using System;

namespace TypesAndEncapsulation.ImplementingDotNetFrameworkInterfaces
{
    public class Order : IComparable
    {
        public DateTime Created { get; set; }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Order o = obj as Order;
            if (o == null)
            {
                throw new ArgumentException("Object is not an Order");
            }
            return this.Created.CompareTo(o.Created);
        }
    }
}