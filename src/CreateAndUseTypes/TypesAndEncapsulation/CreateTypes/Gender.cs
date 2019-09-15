namespace TypesAndEncapsulation.CreateTypes
{
    // enumeration of gender types. This is a special kind of value type
    public enum Gender
    {
        // by default the first element has the value 0 and it is increased by 1
        Female,
        Male,
        Trans
    }

    public enum Weekdays
    {
        // you can explicitely set the starting value.
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
}