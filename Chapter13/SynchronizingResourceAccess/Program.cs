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
            WriteLine($"{Counter} string modifications.");
        }

        // Synchronizing access to shared resources by using flags
        // Declare methods that will access the same resources (A message string)
        static Random r = new Random();
        static string Message; // The shared resource

        // Instantiate an object to be a "conch" (from Lord of The Flies) determining which thread has access
        static object conch = new object();
        static int Counter; // another shared resource - used for atomic operations example

        static void MethodA() {

            // Wrapping the conch in a try-finally to avoid deadlocks by trying to enter the conch with a timeout
            try {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15))) {
                    for (int i = 0; i < 5; i++) {
                        Thread.Sleep(r.Next(2000));
                        Message += "A";
                        Interlocked.Increment(ref Counter); // for atomic operations example
                        Write(".");
                    }
                } else {
                    WriteLine("Method A failed to enter a monitor lock.");
                }
            } finally {
                Monitor.Exit(conch);
            }

        }
        
        static void MethodB() {

            // Wrapping the conch in a try-finally to avoid deadlocks by trying to enter the conch with a timeout
            try {
                if (Monitor.TryEnter(conch, TimeSpan.FromSeconds(15))) {
                    for (int i = 0; i < 5; i++) {
                        Thread.Sleep(r.Next(2000));
                        Message += "B";
                        Interlocked.Increment(ref Counter); // for atomic operations example
                        Write(".");
                    }
                } else {
                    WriteLine("Method B failed to enter a monitor lock.");
                }
            } finally {
                Monitor.Exit(conch);
            }

        }

    }
}
