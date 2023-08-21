using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasa
{
    internal class Person
    {
        public string FirstName { get; protected set; }
        public string FamilyName { get; protected set; }
        public int Age { get; protected set; }

        public Person(string firstName, string familyName, int age)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
        }
    }
}
