using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung
{
    internal static class Personmanager
    {
        public static void WriteColorOuptput(string text, ConsoleColor farbe)
        {
            Console.ForegroundColor = farbe;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        //Neue Person anlegen
        public static void AddNewPerson(List<Person> persons)
        {
            if (persons.Count >= 10)
            {
                WriteColorOuptput("Maximale Personenanzahl erreicht", ConsoleColor.Red);
                return;
            }
            string firstName = "";
            while (true)
            {
                Console.Write("Vorname: ");
                firstName = Console.ReadLine();
                if (!String.IsNullOrEmpty(firstName))
                {
                    break;
                }
                WriteColorOuptput("Vorname darf nicht leer sein", ConsoleColor.Red);
            }
            string lastName = "";
            while (true)
            {
                Console.Write("Nachname: ");
                lastName = Console.ReadLine();
                if (!String.IsNullOrEmpty(lastName))
                {
                    break;
                }
                WriteColorOuptput("Ungültige Eingabe", ConsoleColor.Red);
            }
            int age = -1;
            while (true)
            {
                Console.Write("Alter: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out age) && age >= 0 && age <= 120) {
                    break;
                }
                WriteColorOuptput("Ungültige Eingabe", ConsoleColor.Red);
            }
            string phone = "";
            while (true)
            {
                Console.Write("Telefonnummer: ");
                phone = Console.ReadLine();
                if (!String.IsNullOrEmpty(phone))
                {
                    break;
                }
                WriteColorOuptput("Ungültige Eingabe", ConsoleColor.Red);
            }

            var person = new Person(firstName, lastName, age, phone);
            persons.Add(person);
            WriteColorOuptput("Neue Person erfolgreich angelegt", ConsoleColor.Green);
        }

        public static void ShowAllPersons(IEnumerable<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine($"Name:  {person.FirstName} {person.LastName}");
                Console.WriteLine($"Alter: {person.Age}");
                Console.WriteLine($"Telefonnummer: {person.Phone}");
                Console.WriteLine("\n+++++++++++++++++++++++++++++++\n");
            }
        }
        public static void ShowPersonsOfSpecificAge(List<Person> persons)
        {
            int age = -1;
            while (true)
            {
                Console.Write("Alter: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out age) && age >= 0 && age <= 120)
                {
                    break;
                }
                WriteColorOuptput("Ungültige Eingabe", ConsoleColor.Red);
            }
            Console.WriteLine("Filteroptionen: Älter als (a), Jünger als (j), genau diese Alter (g)");
            string option = Console.ReadLine();
            IEnumerable<Person> filteredPersons;
            while (true)
            {
                switch (option)
                {
                    case "a":
                        filteredPersons = persons.Where(p => p.Age > age).ToList();
                        ShowAllPersons(filteredPersons);
                        return;
                    case "j":
                        filteredPersons = persons.Where(p => p.Age < age).ToList();
                        ShowAllPersons(filteredPersons);
                        return;
                    case "g":
                        filteredPersons = persons.Where(p => p.Age == age).ToList();
                        ShowAllPersons(filteredPersons);
                        return;
                    default:
                        WriteColorOuptput("Ungültige Auswahl", ConsoleColor.Red);
                        break;
                }
            }
        }
     }
}
