using System;
using static System.Console;
using static System.Convert;

namespace CastingConverting {
    class Program {
        static void Main(string[] args) {
            // Implicit casting of int into a double (Safe Cast)
            int a = 10;
            double b = a; // No need to tell the compiler to cast
            WriteLine(b);

            // Unsafe cast - compiler throws an error
            double c = 9.8;
            // int d = c; // Unsafe cast!
            int d = (int) c; // Explicit cast
            WriteLine(d);
            WriteLine();

            // Showing how an unsafe, explicit cast can cause information to be lost:
            long e = 10;
            int f = (int) e;
            WriteLine($"e is {e:N0} and f is {f:N0}");
            e = long.MaxValue;
            f = (int) e;
            WriteLine($"e is {e:N0} and f is {f:N0}");
            e = 5_000_000_000;
            f = (int) e;
            WriteLine($"e is {e:N0} and f is {f:N0}");
            WriteLine();

            // System.Convert as an alternative to the cast operator - can use System.Convert import
            double g = 9.8;
            int h = ToInt32(g); // A benefit is that rounding occurs instead of trimming, unlike a cast
            WriteLine($"g is {g} and h is {h}");
            WriteLine();

            // Rounding in C#'s Convert == Banker's Rounding
            double[] doubles = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };
            foreach (double n in doubles) {
                WriteLine($"ToInt({n}) is {ToInt32(n)}");
            }
            WriteLine();

            // Rounding using Math.Round and "Away From Zero" rule a.k.a. primary school rule
            foreach (double n in doubles) {
                WriteLine("Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
                          n,
                          Math.Round(n, 0, MidpointRounding.AwayFromZero));
            }
            WriteLine();

            // Converting from any type to a string using ToString
            int number = 12;
            WriteLine(number.ToString());
            bool boolean = true;
            WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            WriteLine(now.ToString());
            object me = new object();
            WriteLine(me.ToString());
            WriteLine();

            // Converting binary object to string - e.g. Base64 Encoding
            byte[] binaryObject = new byte[128];
            (new Random()).NextBytes(binaryObject); // Fill with random byte data
            WriteLine("Binary Object as bytes:");
            for (int index = 0; index < binaryObject.Length; index++) {
                Write($"{binaryObject[index]:X}"); // ':X' outputs into hexadecimal notation instead of default decimal
            }
            WriteLine();
            WriteLine();
            // Convert to Base64 string and output as text
            string encoded = ToBase64String(binaryObject);
            WriteLine($"Binary Object as Base64: {encoded}");
            WriteLine();

            // Parsing strings to numbers, dates, or times - 'Parse' as the opposite of 'ToString'
            int age = int.Parse("27"); // Convert string to int
            DateTime birthday = DateTime.Parse("4 July 1980"); // Convert string date to date type
            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}."); // ':D' outputs long date format
            WriteLine();

            // Parse that would cause an error if string cannot be converted:
            // int count = int.Parse("abc"); // Errors out
            // Instead, use TryParse to catch errors
            Write("How many eggs are there? ");
            int count;
            string input = ReadLine();
            if (int.TryParse(input, out count)) {
                WriteLine($"There are {count} eggs.");
            } else {
                WriteLine("I could not parse the input.");
            }
            WriteLine();
        }
    }
}
