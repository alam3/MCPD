using System;
using static System.Console;

namespace WorkingWithRanges {
    class Program {
        static void Main(string[] args) {
            // Exploring Ranges and Spans to work on a subset of a collection
            string name = "Samantha Jones";
            int lengthOfFirst = name.IndexOf(' ');
            int lengthOfLast = name.Length - lengthOfFirst - 1;
            string firstName = name.Substring(startIndex: 0, length: lengthOfFirst);
            string lastName = name.Substring(name.Length - lengthOfLast, lengthOfLast);
            WriteLine($"First name: {firstName}, Last name: {lastName}");

            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0]; // or [^lengthOfLast..], which would work in this case
            WriteLine("First name: {0}, Last name: {1}",
                      arg0: firstNameSpan.ToString(),
                      arg1: lastNameSpan.ToString());
        }
    }
}
