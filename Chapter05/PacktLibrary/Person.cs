using System;
using System.Collections.Generic;

namespace Packt.Shared {
    public class Person : object {
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
    }
}
