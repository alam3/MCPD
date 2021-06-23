using System;
using PrimeFactorsLib;
using System.Collections.Generic;
using static System.Console;

namespace PrimeFactorsCalculator {
    class Program {
        static void Main(string[] args) {
            Write("Which number do you want to prime factorize? ");
            try {
                int input = int.Parse(ReadLine());
                WriteLine($"Prime factors of {input} are: ");
                var pfCalc = new PrimeFactors();
                List<int> pfResults = pfCalc.PrimeFactorsCalc(input);
                foreach (int num in pfResults) {
                    Write($"{num} ");
                }
            } catch (FormatException) {
                WriteLine("The input is not a valid format.");
            } catch (OverflowException) {
                WriteLine("The input value is too big.");
            } catch (Exception e) {
                WriteLine($"{e.GetType()} says {e.Message}");
            }
        }
    }
}
