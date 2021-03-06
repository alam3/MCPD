// using System;
using static System.Console;
using System;

namespace Formatting {
    class Program {
        static void Main(string[] args) {
            int numberOfApples = 12;
            decimal pricePerApple = 0.35M; // M specifies decimal types
            WriteLine(format: "{0} apples cost {1:C}", arg0: numberOfApples, arg1: pricePerApple * numberOfApples);
            // WriteLine("{0} apples cost {1:C}", numberOfApples, pricePerApple * numberOfApples); // Don't need to specify arguments
            // string formatted = string.Format(format: "{0} apples cost {1:C}", arg0: numberOfApples, arg1: pricePerApple * numberOfApples);
            // WriteToFile(formatted);

            // Interpolated String:
            WriteLine($"{numberOfApples} apples cost {pricePerApple * numberOfApples:C}");

            // Format strings
            WriteLine();
            string applesText = "Apples";
            int applesCount = 1234;
            string bananasText = "Bananas";
            int bananasCount = 56789;
            WriteLine(format: "{0,-8} {1,6:N0}",
                              arg0: "Name",
                              arg1: "Count");
            WriteLine(format: "{0,-8} {1,6:N0}",
                              arg0: applesText,
                              arg1: applesCount);
            WriteLine(format: "{0,-8} {1,6:N0}",
                              arg0: bananasText,
                              arg1: bananasCount);

            // Get key inputs from the user
            WriteLine();
            Write("Type your first name and press ENTER: ");
            string firstName = ReadLine();
            Write("Type your age and press ENTER: ");
            string age = ReadLine();
            WriteLine($"Hello {firstName}, you look good for {age}.");

            WriteLine();
            Write("Press any key combination: ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();
            WriteLine("Key: {0}, Char: {1}, Modifiers: {2}", arg0: key.Key, arg1: key.KeyChar, arg2: key.Modifiers);
        }
    }
}
