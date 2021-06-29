using System;
using Packt.Shared;
using static System.Console;
using System.Collections.Generic;

namespace PeopleApp {
    class Program {
        static void Main(string[] args) {
            var bob = new Person();
            WriteLine(bob.ToString()); // Outputs full namespace and type name
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine("{0} was born on {1:dddd, d MMMM yyyy}",
                      arg0: bob.Name,
                      arg1: bob.DateOfBirth);

            // Different object instantiation and DateTime format
            Person alice = new Person {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine("{0} was born on {1:dd MMM yy}",
                      arg0: alice.Name,
                      arg1: alice.DateOfBirth);

            // Adding a selectable enum type
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine("{0}'s favorite wonder is {1}. Its integer is {2}.'",
                      arg0: bob.Name,
                      arg1: bob.FavoriteAncientWonder,
                      arg2: (int)bob.FavoriteAncientWonder);

            // Saving memory space using byte values on enum
            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
                             | WondersOfTheAncientWorld.MausoleumAtHelicarnassus;
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            // Collections
            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe" });
            WriteLine($"{bob.Name} has {bob.Children.Count} children:");
            for (int child = 0; child < bob.Children.Count; child++) {
                WriteLine($"  {bob.Children[child].Name}");
            }
            // Alt
            // foreach (Person child in bob.Children) {
            //     WriteLine($"  {child.Name}");
            // }

            // Adding shared bank account interest and bank accounts
            BankAccount.InterestRate = 0.012M; // Shared value across all BankAccount objects
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine("{0} earned {1:C} interest.",
                      arg0: jonesAccount.AccountName,
                      arg1: jonesAccount.Balance * BankAccount.InterestRate);
            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine("{0} earned {1:C} interest.",
                      arg0: gerrierAccount.AccountName,
                      arg1: gerrierAccount.Balance * BankAccount.InterestRate);

            // Constant fields
            WriteLine($"{bob.Name} is a {Person.Species}");

            // Read-only fields
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            // Using constructors
            Person blankPerson = new Person();
            WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                      arg0: blankPerson.Name,
                      arg1: blankPerson.HomePlanet,
                      arg2: blankPerson.Instantiated);

            Person gunny = new Person("Gunny", "Mars");
            WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                      arg0: blankPerson.Name,
                      arg1: blankPerson.HomePlanet,
                      arg2: blankPerson.Instantiated);

            // Calling Methods
            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            // Calling a tuple method
            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
            // Using var
            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"There are {fruitNamed.Name} {fruitNamed.Number}.");
        }
    }
}
