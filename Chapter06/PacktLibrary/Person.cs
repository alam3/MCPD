using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared {
    public class Person {
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();

        public void WriteToConsole() {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        // Static Method - an action this object type does
        public static Person Procreate(Person p1, Person p2) {
            var baby = new Person {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }

        // Instance Method - actions object does on itself
        public Person ProcreateWith(Person partner) {
            return Procreate(this, partner);
        }

        // Adding operators to perform class functions
        // This simplifies syntax, but is obfuscated from the programmer
        public static Person operator *(Person p1, Person p2) {
            return Person.Procreate(p1, p2);
        }

        // Local or Inner functions in a method
        public static int Factorial(int number) {
            if (number < 0) {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);
            
            // The local function
            int localFactorial(int localNumber) {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }
    }
}
