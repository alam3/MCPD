using System;
using static System.Console;
using System.Reflection;

namespace WorkingWithReflection {
    class Program {
        static void Main(string[] args) {
            WriteLine("Assembly metadata:");
            Assembly assembly = Assembly.GetEntryAssembly();
            WriteLine($" Full name: {assembly.FullName}");
            WriteLine($" Location: {assembly.Location}");
            var attributes = assembly.GetCustomAttributes();
            WriteLine(" Attributes:");
            foreach (Attribute a in attributes) {
                WriteLine($" {a.GetType()}");
            }
        }
    }
}
