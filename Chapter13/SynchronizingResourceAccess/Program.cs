using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace SynchronizingResourceAccess {
    class Program {
        static void Main(string[] args) {
            // Execute both methods on separate threads using a pair of tasks, without any a resource lock
            WriteLine("Please wait for the tasks to complete.");
            Stopwatch watch = Stopwatch.StartNew();
            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);
            Task.WaitAll(new Task[] { a, b });
            WriteLine();
            WriteLine($"Results: {Message}.");
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds");
        }

        // Synchronizing access to shared resources by using flags
        // Declare methods that will access the same resources (A message string)
        static Random r = new Random();
        static string Message; // The shared resource

        static void MethodA() {
            for (int i = 0; i < 5; i++) {
                Thread.Sleep(r.Next(2000));
                Message += "A";
                Write(".");
            }
        }
        
        static void MethodB() {
            for (int i = 0; i < 5; i++) {
                Thread.Sleep(r.Next(2000));
                Message += "B";
                Write(".");
            }
        }

    }
}
