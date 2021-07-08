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
            

            // Creating an instance of the Employee class, inheriting from Person
            Employee john = new Employee {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.WriteToConsole(); // Note how 'Person' class functionality is accessible

            // Adding extra functionality to the 'Employee' class
            // This is not available in an instance of the 'Person' class
            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

            // Overriding parent method (instead of hiding)
            WriteLine(john.ToString());

            // Testing Non-polymorphic vs. Polymorphic inheritance
            Employee aliceInEmployee = new Employee {
                Name = "Alice", EmployeeCode = "AA123" };
            Person aliceInPerson = aliceInEmployee; // Declared as 'Person', but object is still 'Employee' type
            // Hiding is Non-polymorphic inheritance
            aliceInEmployee.WriteToConsole(); // calls method in 'Employee'
            aliceInPerson.WriteToConsole(); // calls method in 'Person' - compiler cannot tell it is an 'Employee'
            // Overriding is Polymorphic inheritance
            WriteLine(aliceInEmployee.ToString()); // calls method in 'Employee'
            WriteLine(aliceInPerson.ToString()); // calls method in 'Employee' - the 'override' and 'virtual' flag for the compiler

            
            // Explicit casting within inheritance hierarchies
            // from 'Person' to 'Employee'
            // Employee explicitAlice = aliceInPerson; // Does not work
            // Employee explicitAlice = (Employee) aliceInPerson; // No problem due to explicit cast

            // Avoiding casting exceptions
            // E.g. what if aliceInPerson turns out to be a different derived type?
            // Check first with 'is' keyword, which compares object types
            if (aliceInPerson is Employee) {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee explicitAlice = (Employee) aliceInPerson;
            }

            // Using 'as' keyword for cast. Returns 'null' if it can't be cast
            Employee aliceAsEmployee = aliceInPerson as Employee;
            if (aliceAsEmployee != null) {
                WriteLine($"{nameof(aliceInPerson)} AS an Employee");
            }

            // Inheriting .NET Type
            // Test: Derived Exception inheriting from .NET Exception type
            try {
                john.TimeTravel(new DateTime(1999, 12, 31));
                john.TimeTravel(new DateTime(1950, 12, 25));
            } catch (PersonException ex) {
                WriteLine(ex.Message);
            }
        }

        // Example of delegates and implementing events
        // Method that receives reference to Person object from Event call
        private static void Harry_Shout(object sender, EventArgs e) {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }
    }
}
