using System;
using System.Linq;
using System.Reflection;

namespace Basics {
    class Program {
        static void Main(string[] args) {

            System.Data.DataSet ds;
            System.Net.Http.HttpClient client;

            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies()) {
                var a = Assembly.Load(new AssemblyName(r.FullName));
                int methodCount = 0;
                foreach (var t in a.DefinedTypes) {
                    methodCount += t.GetMethods().Count();
                }
                Console.WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.",
                                  arg0: a.DefinedTypes.Count(),
                                  arg1: methodCount,
                                  arg2: r.Name);
            }

            Console.WriteLine();
            double heightInMetres = 1.88;
            Console.WriteLine($"The variable {nameof(heightInMetres)} has the value {heightInMetres}.");

            // Literal String - can use escape characters like \t for tabs
            string literalString = "This\tis\ttab\tdelimited";
            // Verbatim String - @ - a literal string with escape characters disabled, avoiding accidental escapes
            string verbatimString = @"This is a filepath: C:\televisions\sony\bravia.txt";
            // Interpolated String - $ - allows embedding variables and operations within a string
            int A = 5;
            int B = 12;
            string interpolatedString = $"A + B is equal to {A + B}";
            
            Console.WriteLine();
            Console.WriteLine(literalString);
            Console.WriteLine(verbatimString);
            Console.WriteLine(interpolatedString);
        }
    }
}
