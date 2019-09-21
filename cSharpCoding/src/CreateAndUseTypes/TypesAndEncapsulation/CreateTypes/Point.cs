namespace TypesAndEncapsulation.CreateTypes
{
    // This is a small example of a value type
    // It is small and immutable. There would be a lot of objects of it.
    public struct Point
    {
        private int x, y;

        // Structs and classes can have methods, fields, properties, constructors, and other functionalities.
        // You cannot, however, declare your own empty constructor for a struct. Also, structs
        // cannot be used in an inheritance hierarchy (which saves you some memory bytes!).
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}