using System;
using PrimeFactorsLib;
using System.Collections.Generic;

namespace PrimeFactorsCalculator {
    class Program {
        static void Main(string[] args) {
            int input = 120;
            Console.WriteLine($"Prime factors of {input} are: ");
            var pfCalc = new PrimeFactors();
            List<int> pfResults = pfCalc.PrimeFactorsCalc(input);
            foreach (int num in pfResults) {
                Console.Write($"{num} ");
            }
        }
    }
}
