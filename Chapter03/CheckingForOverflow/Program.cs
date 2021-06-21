using System;
using static System.Console;

namespace CheckingForOverflow {
    class Program {
        static void Main(string[] args) {
            try {
                checked { // Detects overflows that are normally ignored for performance reasons
                    int x = int.MaxValue - 1;
                    WriteLine($"Initial value: {x}");
                    x++;
                    WriteLine($"After incrementing: {x}");
                    x++;
                    WriteLine($"After incrementing: {x}");
                    x++;
                    WriteLine($"After incrementing: {x}");
                }
            } catch (OverflowException) {
                WriteLine("The code overflowed, but I caught the exception.");
            }

            unchecked {
                int y = int.MaxValue + 1;
                WriteLine($"Initial value: {y}");
                y--;
                WriteLine($"After decrementing {y}");
                y--;
                WriteLine($"After decrementing {y}");
            }

            // Chapter 3 - Exercise01:
            // int zeroInt = 2;
            // WriteLine($"{zeroInt / 0}"); // Gives a "Divide By Zero" Exception
            double zeroDbl = 2.0;
            WriteLine($"{zeroDbl / 0.0}"); // Goes through and outputs infinity
            // for ( ; true; ) ; // Does compile, but runs forever as true condition is never met
            // _ // in a switch expression, represents a match-all pattern, acting as "default"
        }
    }
}
