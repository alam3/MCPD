using System;
using System.IO;
using System.Xml;

namespace Variables {
    class Program {
        static void Main(string[] args) {
            object height = 1.88;
            object name = "Amir";
            Console.WriteLine($"{name} is {height} meters tall.");
            // int length1 = name.Length; // Produces error because object type cannot be determined
            int length2 = ((string)name).Length; // Solved by telling compiler the type through a cast
            Console.WriteLine($"{name} has {length2} characters.");

            // "dynamic" type determines the data's type at a performance and IntelliSense usability cost
            dynamic anotherName = "Ahmed";
            Console.WriteLine($"{anotherName} has {anotherName.Length} characters.");

            // For Local Variables, "var" can be used as a generic type; however it makes readability more difficult
            // using explicit types:
                // int population = 66_000_000; // 66 million in UK 
                // double weight = 1.88; // in kilograms
                // decimal price = 4.99M; // in pounds sterling
                // string fruit = "Apples"; // strings use double-quotes
                // char letter = 'Z'; // chars use single-quotes
                // bool happy = true; // Booleans have value of true or false
            // using "var":
                // var population = 66_000_000; // 66 million in UK 
                // var weight = 1.88; // in kilograms
                // var price = 4.99M; // in pounds sterling
                // var fruit = "Apples"; // strings use double-quotes 
                // var letter = 'Z'; // chars use single-quotes
                // var happy = true; // Booleans have value of true or false

            // With C# 9.0, you can instantiate objects using "target-typed new" "new()":
            XmlDocument xml1 = new XmlDocument(); // Legacy
            XmlDocument xml2 = new(); // New way of instantiation

            // Default values of value-type primitives:
            Console.WriteLine();
            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default(bool) = {default(bool)}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(string) = {default(string)}"); // Not a value-type primitive!
        }
    }
}
