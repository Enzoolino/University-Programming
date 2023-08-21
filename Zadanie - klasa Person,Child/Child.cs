using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie___klasa_Person_Child
{
    class Child : Person
    {

        private readonly Person mother;
        private readonly Person father;

        public Child(string firstName, string familyName, int age, Person mother = null, Person father = null)
            :base(firstName, familyName, age)
        {
            if (age > 15) throw new ArgumentException("Child’s age must be less than 15!");

           
            this.mother = mother;
            this.father = father;
        }

      
        public new void modifyAge(int age)
        {
            if (age < 0 || age > 15) throw new ArgumentException("Child’s age must be less than 15!");

            Age = age;

        }

        public override string ToString()
        {
            string motherData = mother != null ? "mother: " + mother : "mother: No data";
            string fatherData = father != null ? "father: " + father : "father: No data";

            return base.ToString() + $"{Environment.NewLine}" + motherData + $"{Environment.NewLine}" + fatherData;

        }


    }
}
