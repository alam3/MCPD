using System;
using static System.Console;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace LinqInParallel {
    class Program {
        static void Main(string[] args) {
            // Multi-threading
            // First, check performance of creating and squaring 2 billion integers without parallelization
            var watch = new Stopwatch();
            Write("Press ENTER to start: ");
            ReadLine();
            watch.Start();
            IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);
            // var squares = numbers.Select(number => number * number).ToArray(); // Not parallelized
            var squares = numbers.AsParallel()
                                 .Select(number => number * number).ToArray(); // Parallelized
            watch.Stop();
            WriteLine("{0:#,##0} elapsed milliseconds.", watch.ElapsedMilliseconds);
        }
    }
}
