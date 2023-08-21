


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace KlasaWłasna
{
    public class Person
    {
        private string name;
        public string FirstName 
        {
            get => name;
            protected set
            {
                value = value.Trim();
                name = value;
            }
        }

        private string lastName;
        public string FamilyName 
        {
            get => lastName;
            protected set
            {
                lastName = value.Trim().;
                lastName = value;
            }
        }
        public int Age { get;protected set; }


        public Person(string firstName, string familyName, int age)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
        }
        


    }
}