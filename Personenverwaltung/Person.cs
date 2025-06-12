using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung
{
    internal class Person
    {
        private string _firstName;
        public string FirstName { 
            get { return _firstName; }
            set { _firstName = value; }
        }
        //Auto-Property
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string Phone { get; private set; }

        //Konstruktor
        public Person(string firstName, string lastName, int age, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Phone = phone;
        }
    }
}
