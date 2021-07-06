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

            // Statement assigning method to delegate field
            harry.Shout += Harry_Shout;
            // Do the poking...
            harry.Poke();
            harry.Poke();
            harry.Poke(); // Triggers event
            harry.Poke(); // Triggers event

            // Interfaces - IComparable
            Person[] people = { new Person { Name = "Simon" },
                                new Person { Name = "Jenny" },
                                new Person { Name = "Adam" },
                                new Person { Name = "Richard" } };

            WriteLine("Initial list of people:");
            foreach (Person person in people) {
                WriteLine($"  {person.Name}");
            }

            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (Person person in people) {
                WriteLine($"  {person.Name}");
            }

            // Using the ICompare implementation - 'PersonComparer.cs'
            WriteLine("Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (Person person in people) {
                WriteLine($"  {person.Name}");
            }

            // Type Generics - how a non-generic works
            // Despite being able to take any 'object', the function
            // doesn't work as expected:

            // fails despite data and input being the same value
            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");

            // works
            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string: {t2.Process("apple")}");

            // Example of a Generic
            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer: {gt1.Process(42)}");
            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string: {gt2.Process("apple")}");

            // Testing a Generic Method 'Square'
            string number1 = "4";
            WriteLine("{0} squared is {1}",
                      arg0: number1,
                      arg1: Squarer.Square<string>(number1));
            byte number2 = 3;
            WriteLine("{0} squared is {1}",
                      arg0: number2,
                      // Note that specifying <type> isn't required
                      arg1: Squarer.Square(number2));

            // Managing memory with REFERENCES vs VALUE types
            // Using a 'struct' (value type)
            var dv1 = new DisplacementVector(3, 5);
            DisplacementVector dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");
            
        }

        // Example of delegates and implementing events
        // Method that receives reference to Person object from Event call
        private static void Harry_Shout(object sender, EventArgs e) {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }
    }
}
