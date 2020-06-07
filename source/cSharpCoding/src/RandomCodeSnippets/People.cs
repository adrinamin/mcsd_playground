using System;
using System.Collections;
using System.Collections.Generic;

namespace ExamPreparation
{
    public class People : IEnumerable<Person>
    {
        List<Person> _people;
        public People()
        {
            _people = new List<Person>();
        }

        public void AddAscendingByAge(Person person)
        {
            _people.Add(person);
            if (_people.Count > 1)
            {
                // Sorting uses the IComparable implementation in Person class.
                _people.Sort();
            }
        }

        public int CountPeople()
        {
            return _people.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
        {
            return _people.GetEnumerator();
        }
    }

    public class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            var otherPerson = obj as Person;
            if (otherPerson == null)
            {
                throw new ArgumentNullException("This object is not a person.");
            }

            return this.Age.CompareTo(otherPerson.Age);
        }
    }
}