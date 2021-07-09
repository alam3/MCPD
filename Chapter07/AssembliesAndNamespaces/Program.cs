using System;
using static System.Console;
using System.Xml.Linq; // Needs to be added for 'XDocument()' to work,
                       // even if the project has the the reference to the assembly
                       // that contains the type. The compiler doesn't know what
                       // namespace the method belongs to.

namespace AssembliesAndNamespaces {
    class Program {
        static void Main(string[] args) {
            // Needs namespace import to work
            var doc = new XDocument();

            // C# type keywords as aliases of .NET types in a class library assembly
            string s1 = "Hello";
            String s2 = "World"; // Causes compiler error if 'using System;' is removed.
            WriteLine($"{s1} {s2}");

        }
    }
}
