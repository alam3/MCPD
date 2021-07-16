using System;
using System.Collections.Generic;
using static System.Console;

namespace WorkingWithLists {
    class Program {
        static void Main(string[] args) {
            var cities = new List<string>();
            cities.Add("London");
            cities.Add("Paris");
            cities.Add("Milan");
            WriteLine("Initial List");
            foreach (string city in cities) {
                WriteLine($" {city}");
            }

            WriteLine($"The first city is {cities[0]}."); // Lists are indexable
            WriteLine($"The last city is {cities[cities.Count - 1]}."); // Lists have the 'Count' property recording total entries
            cities.Insert(0, "Sydney"); // Inserting at any position of the list
            WriteLine("After inserting Sydney at index 0");
            foreach (string city in cities) {
                WriteLine($" {city}");
            }

            cities.RemoveAt(1); // Removing an entry at a given index
            cities.Remove("Milan"); // Removing an entry by matching content at any entry
            WriteLine("After removing two cities");
            foreach (string city in cities) {
                WriteLine($" {city}");
            }
        }
    }
}
