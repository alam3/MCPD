using System;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WorkingWithTasks {
    class Program {
        static void Main(string[] args) {

            // Running the methods synchronously
            /*
            var timer = Stopwatch.StartNew();
            WriteLine("Running methods synchronously on one thread.");
            MethodA();
            MethodB();
            MethodC();
            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
            */

            // Running the methods in Asynchronously in separate tasks
            var timer = Stopwatch.StartNew();
            WriteLine("Running methods asynchronously on multiple threads.");
            // Three different ways to assign and start new Tasks:
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));

            // Waiting for tasks
            Task[] tasks = { taskA, taskB, taskC };
            Task.WaitAll(tasks);

            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");
        }

        // Methods running at different speeds to show how tasks can be run simultaneously.
        static void MethodA() {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // simulate 3 seconds of work
            WriteLine("Finished Method A.");
        }static void MethodB() {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // simulate 2 seconds of work
            WriteLine("Finished Method B.");
        }static void MethodC() {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // simulate 1 seconds of work
            WriteLine("Finished Method C.");
        }
    }
}
