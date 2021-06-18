using System;
using static System.Console;

namespace IterationStatements {
    class Program {
        static void Main(string[] args) {

            // While loop
            int x = 0;
            while (x < 10) {
                WriteLine(x);
                x++;
            }
            WriteLine();

            // Do-While loop
            string password = string.Empty;
            do {
                Write("Enter your password: ");
                password = ReadLine();
            // } while (password != "Pa$$w0rd");
            } while (password != "");
            WriteLine("Correct!");
            WriteLine();

            // For loop
            for (int y = 1; y <= 10; y++) {
                WriteLine(y);
            }
            WriteLine();

            // Foreach loop
            string[] names = { "Adam", "Barry", "Charlie" };
            foreach (string name in names) {
                WriteLine($"{name} has {name.Length} characters.");
            }
            WriteLine();
        }
    }
}
