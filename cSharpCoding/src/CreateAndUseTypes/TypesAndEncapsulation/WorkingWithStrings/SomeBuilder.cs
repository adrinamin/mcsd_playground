using System;
using System.Text;

namespace TypesAndEncapsulation.WorkingWithStrings
{
    public class SomeBuilder
    {
        public void CreateString(string[] values)
        {
            // The StringBuilder class can be used when you are working with strings in a tight loop. 
            // Instead of creating a new string over and over again, 
            // you can use the StringBuilder, which uses a string buffer internally to improve performance
            var builder = new StringBuilder(string.Empty);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = string.Concat(values[i] + builder.Append('c').ToString());
                Console.WriteLine(values[i]);
            }
        }
    }
}