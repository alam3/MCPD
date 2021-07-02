using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp {
    class Program {
        static void Main(string[] args) {
            Person harry = new Person { Name = "Harry" };
            var mary = new Person { Name = "Mary"};
            Person jill = new Person { Name = "Jill" };

            // instance method call
            var baby1 = mary.ProcreateWith(harry);
            baby1.Name = "Gary";

            // static method call
            var baby2 = Person.Procreate(harry, jill);
            
            // Calling the operator assigned to a function
            Person baby3 = harry * mary; // what a cheating bastard

            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine("{0}'s first child is named \"{1}\".",
                      harry.Name,
                      harry.Children[0].Name);

            // Calling a method with a local function
            WriteLine($"5! is {Person.Factorial(5)}");
        }
    }
}
