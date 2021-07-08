using System;
using static System.Console;
using System.Collections.Generic;

namespace Packt.Shared {
    public class Person : IComparable<Person> {
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

        // Example of using delegates and implementing events
        // Event delegate field
        // Add a 'event' keyword so the delegate field can only have
        // methods assigned or removed using '+=' or "-=" respectively
        public event EventHandler Shout;

        // Data field
        public int AngerLevel;
        
        // method - if "poked" 3 times, raise "Shout" event
        public void Poke() {
            AngerLevel++;
            if (AngerLevel >= 3) {
                // if something is listening...
                if (Shout != null) {
                    // ...then call the delegate
                    Shout(this, EventArgs.Empty);
                }
                // C#6.0+ simplified inline null-check call
                // Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        // Method implementation of IComparable Interface
        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        // Inheriting .NET Type
        // Test: Define method that throws exception if date/time
        // parameter is earlier than Person's date of birth
        public void TimeTravel(DateTime when) {
            if (when <= DateOfBirth) {
                throw new PersonException("If you travel back in time to a date earlier than your birth, then the universe will explode!");
            } else {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }
    }
}
