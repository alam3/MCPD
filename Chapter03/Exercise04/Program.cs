using System;
using static System.Console;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            byte firstInput;
            byte secondInput;
            try {
                Write("Enter a number between 0 and 255: ");
                firstInput = byte.Parse(ReadLine());
                Write("Enter another number between 0 and 255: ");
                secondInput = byte.Parse(ReadLine());
                WriteLine($"{firstInput} divided by {secondInput} is {firstInput / secondInput}");
            } catch (FormatException fe) {
                WriteLine($"{fe.Message}");
            } catch {
                WriteLine("An input is out of range.");
            }


            // Exercise 05
            WriteLine();
            int x1 = 3;
            int y1 = 2 + ++x1;
            WriteLine($"x1: 3; y1 = 2 + ++x1: {y1}"); // Results in 6;

            int x2 = 3 << 2;
            int y2 = 10 >> 1;
            WriteLine($"x2: {x2}; y2: {y2}"); // x2 == 12; y2 == 5
            
            int x3 = 10 & 8;
            int y3 = 10 | 7;
            WriteLine($"x3 = 10 & 8: {x3}; y3 = 10 | 7: {y3}"); // x3 == 8; y3 == 15
        }
    }
}
