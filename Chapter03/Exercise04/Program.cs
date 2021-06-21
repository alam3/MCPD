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
        }
    }
}
