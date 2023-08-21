using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadanie___klasa_Person_Child
{
    public class Person
    {
        private string _imie;
        public string FirstName
        {
            get => _imie;
            protected set
            {
                value = value.Trim();
                value = String.Join("", value.Split(' '));
                value = value.First().ToString().ToUpper() + value.Substring(1).ToLower();

                if (Regex.IsMatch(value, @"^[a-zA-Z]+$")==false || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Wrong name!");
                }

                _imie = value;

            }
        }


        private string _nazwisko;
        public string FamilyName
        {
            get => _nazwisko;
            protected set
            {
                value = value.Trim();
                value = String.Join("", value.Split(' '));
                value = value.First().ToString().ToUpper() + value.Substring(1).ToLower();

                if (Regex.IsMatch(value, @"^[a-zA-Z]+$")==false || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Wrong name!");
                }

                _nazwisko = value;
            }
        }

        private int _wiek;

        public int Age
        {
            get => _wiek;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                _wiek = value;


            }
        }


        public Person (string firstName, string familyName, int age)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {FamilyName} ({Age})";
        }


        public void modifyFirstName (string firstName)
        {
            FirstName = firstName.Trim();
            FirstName = String.Join("", firstName.Split(' '));
            FirstName = firstName.First().ToString().ToUpper() + firstName.Substring(1).ToLower();

            if (Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") == false || String.IsNullOrEmpty(FirstName))
            {
                throw new ArgumentException("Wrong name!");
            }
        }

        public void modifyFamilyName (string familyName)
        {
            FamilyName = familyName.Trim();
            FamilyName = String.Join("", familyName.Split(' '));
            FamilyName = familyName.First().ToString().ToUpper() + familyName.Substring(1).ToLower();

            if (Regex.IsMatch(FamilyName, @"^[a-zA-Z]+$") == false || String.IsNullOrEmpty(FamilyName))
            {
                throw new ArgumentException("Wrong name!");
            }
        }

        public void modifyAge (int age)
        {
            if (age < 0)
                throw new ArgumentException("Age must be positive!");

            Age = age;
        }


    }
}
