#nullable enable

using System;

namespace NullHandling {
    class Program {
        static void Main(string[] args) {
            // Nullable value types using '?'
            // int thisCannotBeNull = 4;
            // thisCannotBeNull = null; // gives an error as int cannot be null
            int? thisCouldBeNull = null;
            Console.WriteLine(thisCouldBeNull); // Empty output because it is null
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault()); // Outputs default
            thisCouldBeNull = 7;
            Console.WriteLine(thisCouldBeNull); // Outputs assigned value
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault()); // Same as above

            Address address = new();
            address.Building = null;
            // address.Street = null; // Gives error because it has been made non-nullable
            address.City = "London";
            // address.Region = null; // Gives error because it has been made non-nullable

            string authorName = null;
            // int x = authorName.Length; // This will fail because int cannot know if the authorName.Length is null
            int? y = authorName?.Length; // The '?' tells the compiler this may be a null value
            Console.WriteLine(y); // Empty output

            // Null-coalescing operator '??' assigns a variable to a result or value if it is null
            var result = authorName?.Length ?? 3;
            Console.WriteLine(result); // Outputs 3 because authorName is null
        }
    }

    class Address {
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }
}
