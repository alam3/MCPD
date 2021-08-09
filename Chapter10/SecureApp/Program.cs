using System;
using static System.Console;
using Packt.Shared;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;

namespace SecureApp {
    class Program {
        static void Main(string[] args) {
            // Authentication and Authorization
            // Register 3 users in various roles, prompt them to log in, and output info about them if legitimate auth

            Protector.Register("Alice", "Pa$$w0rd", new[] { "Admins" });
            Protector.Register("Bob", "Pa$$w0rd", new[] { "Sales", "TeamLeads" });
            Protector.Register("Eve", "Pa$$w0rd");

            Write($"Enter your user name: ");
            string username = ReadLine();
            Write($"Enter your password: ");
            string password = ReadLine();
            Protector.LogIn(username, password);
            if (Thread.CurrentPrincipal == null) {
                WriteLine("Log in failed.");
                return;
            }

            var p = Thread.CurrentPrincipal;
            WriteLine($"IsAuthenticated: {p.Identity.IsAuthenticated}");
            WriteLine($"AuthenticationType: {p.Identity.AuthenticationType}");
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");
            WriteLine($"IsInRole(\"TeamLeads\"): {p.IsInRole("TeamLeads")}");

            if (p is ClaimsPrincipal) { 
                WriteLine($"{p.Identity.Name} has the following claims:");
                foreach (Claim claim in (p as ClaimsPrincipal).Claims) {
                    WriteLine($"{claim.Type}: {claim.Value}");
                }
            }
        }
    }
}
