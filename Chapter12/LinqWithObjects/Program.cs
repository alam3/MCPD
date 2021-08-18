using System;
using static System.Console;
using System.Linq; // Requires to use the extension methods for array/collection types

namespace LinqWithObjects {
    class Program {
        static void Main(string[] args) {
            // LinqWithArrayOfStrings();
            LinqWithArrayOfExceptions();
        }

        static void LinqWithArrayOfStrings() {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed"};
            // var query = names.Where(new Func<string, bool>(NameLongerThanFour)); // Delegate needs to be passed the string of the method to use
            // var query = names.Where(NameLongerThanFour); // Simplified where the explicit instantiation of the delegate is removed
            var query = names
                .Where(name => name.Length > 4) // Simplified further using Lambda Expressions, where a separate method is not required
                .OrderBy(name => name.Length) // Sorting using OrderBy
                // .OrderByDescending(name => name.Length); // Sorting using OrderByDescending
                .ThenBy(name => name); // Using ThenBy to sort by additional value
            
            foreach (string item in query) {
                WriteLine(item);
            }
        }

        // static bool NameLongerThanFour(string name) {
        //     return name.Length > 4;
        // }

        static void LinqWithArrayOfExceptions() {
            var errors = new Exception[] {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };

            var numberErrors = errors.OfType<ArithmeticException>();
            foreach (var error in numberErrors) {
                WriteLine(error);
            }
        }

    }
}
