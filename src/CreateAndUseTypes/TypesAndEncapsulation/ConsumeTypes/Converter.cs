using System;
using TypesAndEncapsulation.CreateTypes;

namespace TypesAndEncapsulation.ConsumeTypes
{
    public class Converter
    {
        // An implicit conversion doesn’t need any special syntax. 
        // It can be executed because the compiler knows that the conversion is allowed and that it’s safe to convert.
        public void ConvertIntToDouble(int i)
        {
            double d = i;
        }

        public void ConvertDoubleToIntExplicitly(double d)
        {
            int a = (int)d;
        }

        // Another implicit conversion is that from a reference type to one of its base types.
        internal void ConvertPersonToEmployee(Employee employee)
        {
            Person person = employee;

        }

        internal void ConvertCustomerToEmployee(Employee employee)
        {
            Customer customer = employee;
        }

        // Conversions with a helper class
        // The .NET Framework also offers helper classes for conversions between types. For converting
        // between noncompatible types, you can use System.BitConverter. For conversion between
        // compatible types, you can use System.Convert and the Parse or TryParse methods on various
        // types.
        public void ConvertWithHelperClasses()
        {
            int value = Convert.ToInt32(4.5);
            value = int.Parse("4.5");
        }

    }
}