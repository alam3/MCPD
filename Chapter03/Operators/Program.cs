﻿using System;
using static System.Console;

namespace Operators {
    class Program {
        static void Main(string[] args) {
            int a = 3;
            int b = a++;
            WriteLine($"a is {a}, b is {b}"); // Assign a to b FIRST, then increment

            int c = 3;
            int d = ++c;
            WriteLine($"c is {c}, d is {d}"); // Increment c FIRST, then assign to d

            int e = 11;
            int f = 3;
            WriteLine($"e is {e}, f is {f}");
            WriteLine($"e + f = {e + f}");
            WriteLine($"e - f = {e - f}");
            WriteLine($"e * f = {e * f}");
            WriteLine($"e / f = {e / f}");
            WriteLine($"e % f = {e % f}");

            double g = 11.0;
            WriteLine($"g is {g:N1}, f is {f}");
            WriteLine($"g / f = {g / f:N2}");

            int p = 6;
            p += 3; // p = p + 3
            p -= 3; // p = p - 3
            p *= 3; // p = p * 3
            p /= 3; // p = p / 3
            WriteLine($"p is {p}");
        }
    }
}
