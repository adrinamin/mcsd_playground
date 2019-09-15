using System;

namespace TypesAndEncapsulation.CreateTypes
{
    internal class Customer : Person
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly int age;

        public Customer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            this.age = age;
            this.lastName = lastName ?? throw new System.ArgumentNullException(nameof(lastName));
            this.firstName = firstName ?? throw new System.ArgumentNullException(nameof(firstName));
        }

        // This is where the virtual and override keywords come into play. Marking a method virtual
        // allows derived classes to override the method. The derived class can choose to completely
        // replace or to extend the behavior of the base class.
        protected override void Walk(int distance = 0)
        {
            Console.WriteLine("I'm walking very slowly {0} meters", distance);
        }

        // Adding these kinds of conversion can really improve the usability of your type. As you can
        // see, the implicit and explicit operator should be declared as a public static method on your
        // class. You need to specify the return type (the type you are casting to) and the type you are
        // casting from (an instance of your class).
        public static implicit operator Customer(Employee v)
        {
            return v;
        }
    }
}