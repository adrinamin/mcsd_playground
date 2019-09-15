using System;

namespace TypesAndEncapsulation.CreateTypes
{
    internal abstract class Person
    {
        // fields are used to store data inside a class
        private readonly string _name;
        private readonly int _age;

        protected Person(string firstName, string lastName, int age) : this(firstName + lastName, age) { }

        protected Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
        protected string Name { get => _name; }
        protected int Age { get => _age; }

        protected virtual void Walk(int distance = 0)
        {
            Console.WriteLine("I'm walking {0} meters.", distance);
        }

        // It’s also possible to create methods with the same name that differ in the arguments they
        // take, which is called overloading.
        protected virtual void Walk(int distance = 0, string mood = "happy")
        {
            Console.WriteLine("I'm walking {0} {1} meters");
        }
    }
}