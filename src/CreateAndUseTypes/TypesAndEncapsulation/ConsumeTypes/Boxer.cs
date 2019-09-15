namespace TypesAndEncapsulation.ConsumeTypes
{
    public class Boxer
    {
        // The important difference between a value type and a reference type is that the value type
        // stores its value directly. A reference type stores a reference that points to an object on the
        // heap that contains the value.
        // So boxing is the process of taking a value type, putting it inside a new object on the heap,
        // and storing a reference to it on the stack. Unboxing is the exact opposite: It takes the item
        // from the heap and returns a value type that contains the value from the heap.
        public void BoxInteger()
        {
            //If you execute an invalid unbox operation, the runtime will throw an InvalidCastException. 
            // You won’t see the error at compile time because the compiler trusts you in making the right call. 
            // At runtime, however, the conversion fails, and an exception is thrown.
            int number = 45;
            object o = number;
            int number2 = (int)o;
        }
    }
}