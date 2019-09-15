using System;

namespace TypesAndEncapsulation.CreateTypes
{
    internal class Employee : Person
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly int age;

        public Employee(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            this.age = age;
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        }

        protected override void Walk(int distance = 0)
        {
            Console.WriteLine("I'm actually running {0} meters", distance);
        }
    }
}