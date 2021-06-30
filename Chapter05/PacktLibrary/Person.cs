using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared {
    public partial class Person : object {
        // fields
        public string Name;
        public DateTime DateOfBirth;

        // Enums
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;

        // Collections
        public List<Person> Children = new List<Person>();

        // Constant fields
        public const string Species = "Homo Sapien";

        // Read-only fields - better alternative to constants
        // Could also be made static to share across all instances of the type
        public readonly string HomePlanet = "Earth";

        // Initializing fields with constructors
        public readonly DateTime Instantiated;
        // Person-type object constructor
        public Person() {
            // Set values upon object instantiation
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet) {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        // Writing Methods
        public void WriteToConsole() {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }
        public string GetOrigin() {
            return $"{Name} was born on {HomePlanet}.";
        }

        // Tuple-return methods
        public (string, int) GetFruit() {
            return ("Apples", 5);
        }

        public (string Name, int Number) GetNamedFruit() {
            // return (Name: "Apples", Number: 5);
            return ("Apples", 5);
        }

        // Method parameters & method overload
        public string SayHello() {
            return $"{Name} says 'Hello!'";
        }
        // Overloaded method 'SayHello'
        public string SayHello(string name) {
            return $"{Name} says 'Hello {name}!'";
        }

        // Optional parameters
        public string OptionalParameters(string command = "Run!", double number = 0.0, bool active = true) {
            return string.Format("command is {0}, number is {1}, active is {2}", 
                                 arg0: command, arg1: number, arg2: active);
        }

        // Controlling parameters passed in a call
        public void PassingParameters(int x, ref int y, out int z) {
            // 'out' parameters must be initialized inside the method
            z = 99;
            x++;
            y++;
            z++;
        }

        // Splitting a class using the 'partial' keyword - see PersonAutoGen.cs
        // Added "partial" to Person class
    }
}
