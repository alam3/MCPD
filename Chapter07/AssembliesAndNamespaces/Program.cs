using System;
using System.Xml.Linq; // Needs to be added for 'XDocument()' to work,
                       // even if the project has the the reference to the assembly
                       // that contains the type. The compiler doesn't know what
                       // namespace the method belongs to.

namespace AssembliesAndNamespaces {
    class Program {
        static void Main(string[] args) {
            var doc = new XDocument();
        }
    }
}
