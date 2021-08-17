using System;
using static System.Console;
using System.Linq; // Requires to use the extension methods for array/collection types

namespace LinqWithObjects {
    class Program {
        static void Main(string[] args) {
            LinqWithArrayOfStrings();
        }

        static void LinqWithArrayOfStrings() {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed"};
            // var query = names.Where(new Func<string, bool>(NameLongerThanFour)); // Delegate needs to be passed the string of the method to use
            var query = names.Where(NameLongerThanFour); // Simplified where the explicit instantiation of the delegate is removed
            foreach (string item in query) {
                WriteLine(item);
            }
        }

        static bool NameLongerThanFour(string name) {
            return name.Length > 4;
        }

    }
}
