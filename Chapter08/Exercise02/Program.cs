using System;
using static System.Console;
using System.Text.RegularExpressions;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            ConsoleKeyInfo endkey;
            do {
                DoRegex();
                endkey = ReadKey();
            } while (endkey.Key != ConsoleKey.Escape);
        }

        public static void DoRegex() {
            Write("\nEnter a regular expression (or press ENTER to use the default): ");
            string regex = ReadLine();
            Write("Enter some input: ");
            string matchInput = ReadLine();
            Regex inputChecker = new Regex(regex);
            WriteLine($"{matchInput} matches {regex}? {inputChecker.IsMatch(matchInput)}");
            WriteLine("Press ESC to end or any key to try again.");
        }
    }
}
