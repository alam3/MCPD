using System;
using static System.Console;

namespace WorkingWithText {
    class Program {
        static void Main(string[] args) {

            // Working with Text types - StringBuilder and Regex help with manipulating strings
            string city = "London";
            WriteLine($"{city} is {city.Length} characters long.");

            // 'string' class stores text in an array of 'char'
            WriteLine($"First char is {city[0]} and third is {city[2]}.");

            // String splitting 
            string citiesCommaSplit = "Paris,Berlin,Madrid,New York";
            string citiesTabSplit = "Paris\tBerlin\tMadrid\tNew York";
            string [] citiesCommaSplitArray = citiesCommaSplit.Split(',');
            string [] citiesTabSplitArray = citiesTabSplit.Split('\t');
            WriteLine($"Split by commas: \"{citiesCommaSplit}\"");
            foreach (string item in citiesCommaSplitArray) {
                WriteLine(item);
            }
            WriteLine($"Split by tabs: \"{citiesTabSplit}\"");
            foreach (string item in citiesTabSplitArray) {
                WriteLine(item);
            }

            // Getting part of a string
            string fullName = "Alan Jones";
            int indexOfTheSpace = fullName.IndexOf(' ');
            string firstName = fullName.Substring(0, indexOfTheSpace);
            string lastName = fullName.Substring(indexOfTheSpace + 1);
            WriteLine($"Index of space character: {indexOfTheSpace}");
            WriteLine($"First name: {firstName}.");
            WriteLine($"Last name: {lastName}.");

            // Checking a string for content
            string company = "Microsoft";
            bool startsWithM = company.StartsWith("M");
            bool containsN = company.Contains("N");
            WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}");
        }
    }
}
