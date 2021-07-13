using System;
using static System.Console;
using System.Xml.Linq; // Needs to be added for 'XDocument()' to work,
                       // even if the project has the the reference to the assembly
                       // that contains the type. The compiler doesn't know what
                       // namespace the method belongs to.
using Packt.Shared; // Import Packt.Shared namespace
using DialectSoftware.Collections; // Test an old 2013 package from DialectSoftware
using DialectSoftware.Collections.Generics;

namespace AssembliesAndNamespaces {
    class Program {
        static void Main(string[] args) {
            // Needs namespace import to work
            var doc = new XDocument();

            // C# type keywords as aliases of .NET types in a class library assembly
            string s1 = "Hello";
            String s2 = "World"; // Causes compiler error if 'using System;' is removed.
            WriteLine($"{s1} {s2}");

            // Testing packaged library in NuGet (Packt.CSdotnet.SharedLibrary)
            Write("Enter a color value in hex: ");
            string hex = ReadLine();
            WriteLine("Is {0} a valid color value? {1}", arg0: hex, arg1: hex.IsValidHex());

            Write("Enter a XML element: ");
            string xmlTag = ReadLine();
            WriteLine("Is {0} a valid XML element? {1}", arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());
            Write("Enter a password: ");
            string password = ReadLine();
            WriteLine("Is {0} a valid password? {1}", arg0: password, arg1: password.IsValidPassword());

            // Test an old 2013 package from DialectSoftware
            // The compiler will throw errors because it does not know if it will work with .NET 5
            // Program will run, however, because it is .NET-standard compatible, which is not a guarantee for other packages
            var x = new Axis("x", 0, 10, 1);
            var y = new Axis("y", 0, 4, 1);
            var matrix = new Matrix<long>(new[] { x, y });
            for (int i = 0; i < matrix.Axes[0].Points.Length; i++) {
                matrix.Axes[0].Points[i].Label = "x" + i.ToString();
            }
            for (int i = 0; i < matrix.Axes[1].Points.Length; i++) {
                matrix.Axes[1].Points[i].Label = "y" + i.ToString();
            }
            foreach (long[] c in matrix) {
                matrix[c] = c[0] + c[1];
            }
            foreach (long[] c in matrix) {
                WriteLine("{0},{1} ({2},{3}) = {4}",
                          matrix.Axes[0].Points[c[0]].Label,
                          matrix.Axes[1].Points[c[1]].Label,
                          c[0], c[1], matrix[c]);
            }

        }
    }
}
