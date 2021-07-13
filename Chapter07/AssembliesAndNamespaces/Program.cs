using System;
using static System.Console;
using System.Xml.Linq; // Needs to be added for 'XDocument()' to work,
                       // even if the project has the the reference to the assembly
                       // that contains the type. The compiler doesn't know what
                       // namespace the method belongs to.
using Packt.Shared; // Import Packt.Shared namespace

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

        }
    }
}
