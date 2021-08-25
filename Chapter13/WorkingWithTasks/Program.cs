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

            /*
            // Three different ways to assign and start new Tasks:
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));

            // Waiting for tasks
            Task[] tasks = { taskA, taskB, taskC };
            Task.WaitAll(tasks);
            */

            // Continuation Tasks
            WriteLine("Passing the result of one task as an input into another.");
            var taskCallWebServiceAndThenStoredProcedure = Task.Factory.StartNew(CallWebService)
                                                               .ContinueWith(previousTask =>
                                                                   CallStoredProcedure(previousTask.Result));
            WriteLine($"Result: {taskCallWebServiceAndThenStoredProcedure.Result}");

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

        // Continuation Tasks: types of tasks that allow for waiting for a
        // task dependency before initiating the dependent task
        // Simulate calling a web service that returns information needed to run a subsequent task
        static decimal CallWebService() {
            WriteLine("Starting call to web service...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to web service.");
            return 89.99M;
        }
        static string CallStoredProcedure(decimal amount) {
            WriteLine("Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to stored procedure.");
            return $"12 products cost more than {amount:C}.";
        }
    }
}
