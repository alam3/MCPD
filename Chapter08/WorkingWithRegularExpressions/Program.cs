using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace WorkingWithRegularExpressions {
    class Program {
        static void Main(string[] args) {
            Write("Enter your age: ");
            string input = ReadLine();
            var ageChecker = new Regex(@"^\d+$"); // Form Regex to check that input is a digit
            // '@' switches off the use of escape characters, making '\d' interpretable as a RegEx
            // '^' means to match the starting position of a string, 
            // making it so that it will only accept a string starting with a digit
            // '$' matches the end position of a string. In the case '^\d$', only one digit is detected
            // '+' makes it so there is one or more of the preceeding expression ('\d' in this case)
            if (ageChecker.IsMatch(input)) {
                WriteLine("Thank you!");
            } else {
                WriteLine($"This is not a valid age: {input}");
            }

            // Separating strings with RegEx
            // Example using Split() and why RegEx is better
            string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
            string[] filmsDumb = films.Split(',');
            WriteLine("Dumb attempt at splitting:");
            foreach (string film in filmsDumb) {
                WriteLine(film);
            }
            // RegEx example
            var csv = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
            MatchCollection filmsSmart = csv.Matches(films);
            WriteLine("Smart attempt at splitting:");
            foreach (Match film in filmsSmart) {
                WriteLine(film.Groups[2].Value);
            }
        }
    }
}
