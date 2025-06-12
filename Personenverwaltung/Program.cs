using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung
{
    internal class Program
    {
        static void Main(string[] args)

        {
            List<Person> persons = new List<Person>();

            Console.Clear();
            Console.WriteLine("Willkommen bei Nadines Personenverwaltung");
            while (true)
            {
                Console.WriteLine("Verfügbare Option: ");
                Console.WriteLine("Neue Person anlegen (n), Anzeige aller Personen (a), Anzeige der Personen nach Alter filtern (f), Beenden (x)");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "n":
                        Personmanager.AddNewPerson(persons);
                        break;
                    case "a":
                        Personmanager.ShowAllPersons(persons);
                        break;
                    case "f":
                        Personmanager.ShowPersonsOfSpecificAge(persons);
                        break;
                    case "x":
                        Console.WriteLine("Drücken Sie eine beliebige Taste zum Beenden...");
                        Console.ReadKey();
                        return;
                    default:
                        Personmanager.WriteColorOuptput("Ungültige Auswahl", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}
