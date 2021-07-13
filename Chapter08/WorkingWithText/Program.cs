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
        }
    }
}
