using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncEnumerable {
    class Program {

        // Example of Async support on streams

        static async Task Main(string[] args) {
            await foreach (int number in GetNumbers()) {
                WriteLine($"Number: {number}");
            }
        }

        async static IAsyncEnumerable<int> GetNumbers() {
            var r = new Random();
            // simulate work - Tasks getting random numbers asynchronously
            await Task.Run(() => Task.Delay(r.Next(1500, 3000)));
            yield return r.Next(0, 1001);
            await Task.Run(() => Task.Delay(r.Next(1500, 3000)));
            yield return r.Next(0, 1001);
            await Task.Run(() => Task.Delay(r.Next(1500, 3000)));
            yield return r.Next(0, 1001);
        }
    }
}
