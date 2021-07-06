using System;
using System.Threading;

namespace Packt.Shared {
    // Using Generics for Methods

    // The class 'Squarer' is NOT generic
    public static class Squarer {
        // The 'Square' method IS generic
        // Implementing 'IConvertible' gives 'T' a 'ToDouble()" method
        public static double Square<T>(T input) where T : IConvertible {
            // Convert using the current culture
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);
            return d * d;
        }
    }
}