using System;
using static System.Console;
using System.Reflection;
using System.Linq; // For custom attributes. Import to use OrderByDescending
using System.Runtime.CompilerServices; // For custom services. Import to use CompilerGeneratedAttribute
using Packt.Shared; // For custom attributes. Import to bring in CoderAttribute class

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


            // Adding information. These show generic info when run without editing the *.csproj
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($" Version: {version.InformationalVersion}");
            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($" Company: {company.Company}");

            // Get types, enumerate members, and read custom attribute 'Coder' from them
            WriteLine();
            WriteLine($"* Types:");
            Type[] types = assembly.GetTypes();
            foreach (Type type in types) {
                WriteLine();
                WriteLine($"Type: {type.FullName}");
                MemberInfo[] members = type.GetMembers();
                foreach (MemberInfo member in members) {
                    WriteLine("{0}: {1} ({2}))",
                              arg0: member.MemberType,
                              arg1: member.Name,
                              arg2: member.DeclaringType);
                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);
                    foreach (CoderAttribute coder in coders) {
                        WriteLine("-> Modified by {0} on {1}",
                                  coder.Coder,
                                  coder.LastModified.ToShortDateString());
                    }
                }
            }
        }

        [Coder("Mark Price", "22 August 2019")]
        [Coder("Johnni Rasmussen", "13 September 2019")]
        public static void DoStuff() {

        }
    }
}
