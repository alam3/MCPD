using System;
using static System.Console;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            int max = 500;
            try { // Add this to branch in case of overflow
                checked { // Add this to prevent overflow-related infinite for-loop
                    for (byte i = 0; i < max; i++) {
                        WriteLine(i);
                    }
                }
            } catch (OverflowException oe) {
                WriteLine($"{oe.Message}");
            }
        }
    }
}
