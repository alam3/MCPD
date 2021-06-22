﻿using System;
using static System.Console;

namespace WritingFunctions {
    class Program {
        static void TimesTable(byte number) {
            WriteLine($"This is the {number} times table:");
            for (int row = 1; row <= 12; row++) {
                WriteLine($"{row} x {number} = {row * number}");
            }
            WriteLine();
        }

        static void RunTimesTable() {
            bool isNumber;
            do {
                Write("Enter a number between 0 and 255: ");
                isNumber = byte.TryParse(ReadLine(), out byte number);
                if (isNumber) {
                    TimesTable(number);
                } else {
                    WriteLine("You did not enter a valid number!");
                }
            } while (isNumber);
        }

        static decimal CalculateTax(decimal amount, string twoLetterRegionCode) {
            decimal rate = 0.0M;
            switch (twoLetterRegionCode) {
                case "ch": // Switzerland
                    rate = 0.08M;
                    break;
                case "dk": // Denmark
                case "no": // Norway, same as Denmark
                    rate = 0.25M;
                    break;
                case "gb": // United Kingdom
                case "uk": // Alternative for UK
                case "fr": // France, same as UK
                    rate = 0.2M;
                    break;
                case "hu":
                    rate = 0.27M;
                    break;
                case "or": // Oregon
                case "ak": // Alaska
                case "mt": // Montana
                    rate = 0.0M;
                    break;
                case "nd": // North Dakota
                case "wi": // Wisconsin
                case "me": // Maryland
                case "va": // Virginia
                    rate = 0.05M;
                    break;
                case "ca": // California
                    rate = 0.0825M;
                    break;
                default: // most US states
                    rate = 0.06M;
                    break;
            }
            return amount * rate;
        }

        static void RunCalculateTax() {
            Write("Enter an amount: ");
            string amountInText = ReadLine();
            Write("Enter a two-letter region code: ");
            string region = ReadLine().ToLower();
            if (decimal.TryParse(amountInText, out decimal amount)) {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            } else {
                WriteLine("You did not enter a valid amount!");
            }
        }

        /// <summary>
        /// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
        /// </summary>
        /// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
        /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
        static string CardinalToOrdinal(int number) {
            switch (number) {
                case 11: // special cases for 11th to 13th
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    int lastDigit = number % 10;
                    string suffix = lastDigit switch {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th"
                    };
                    return $"{number}{suffix}";
            }
        }

        static void RunCardinalToOrdinal() {
            for (int number = 1; number <= 40; number++) {
                Write($"{CardinalToOrdinal(number)} ");
            }
            WriteLine();
        }

        static int Factorial(int number) {
            if (number < 1) {
                return 0;
            } else if (number == 1) {
                return 1;
            } else {
                checked {
                    return number * Factorial(number - 1);
                }
            }
        }

        static void RunFactorial() {
            for (int i = 1; i < 15; i++) {
                try {
                    WriteLine($"{i}! = {Factorial(i):N0}");
                } catch (System.OverflowException) {
                    WriteLine($"{i}! is too big for a 32-bit integer.");
                }
            }
        }

        static void Main(string[] args) {
            // RunTimesTable();
            // RunCalculateTax();
            // RunCardinalToOrdinal();
            RunFactorial();
        }
    }
}