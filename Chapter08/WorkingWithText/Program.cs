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

            // Additional string members (joining, formatting, etc.)
            string recombined = string.Join(" => ", citiesCommaSplitArray); // first input determines the "joining" element
            WriteLine(recombined);

            string fruit = "Apples";
            decimal price = 0.39M; // Haha apples for $0.39, nice joke
            DateTime when = DateTime.Today;
            WriteLine($"{fruit} cost {price:C} on {when:dddd}s."); // '$' token formatting
            WriteLine(string.Format("{0} cost {1:C} on {2:dddd}s.", fruit, price, when)); // Formatting with string.Format()

            string lowerCaseString = "i am lower case";
            WriteLine($"{lowerCaseString} => to upper case => {lowerCaseString.ToUpper()}");
            string upperCaseString = "I AM UPPER CASE";
            WriteLine($"{upperCaseString} => to lower case => {upperCaseString.ToLower()}");

            string whitespaceString = "    <-4 spaces | 8 spaces ->        ";
            WriteLine($"Original string: \"{whitespaceString}\"");
            WriteLine($"Trim both: \"{whitespaceString.Trim()}\"");
            WriteLine($"Trim start: \"{whitespaceString.TrimStart()}\"");
            WriteLine($"Trim end: \"{whitespaceString.TrimEnd()}\"");

            string removeThis = "removeTHIS";
            WriteLine($"{removeThis} => {removeThis.Remove(6, 4)}");
            string insertThis = "insert";
            WriteLine($"{insertThis} => {insertThis.Insert(6, "THIS")}");
            string replaceThis = "replaceTHIS";
            WriteLine($"{replaceThis} => {replaceThis.Replace("THIS", "THAT")}");

        }
    }
}
