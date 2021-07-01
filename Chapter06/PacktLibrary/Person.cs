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
    }
}
