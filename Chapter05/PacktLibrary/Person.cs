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
    }
}
