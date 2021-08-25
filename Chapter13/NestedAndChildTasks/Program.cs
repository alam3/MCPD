using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace NestedAndChildTasks {
    class Program {
        static void Main(string[] args) {

            // Nested tasks: Tasks that are created inside another task
            // Child task: A task that must finish before its Parent task can continue and finish

            var outer = Task.Factory.StartNew(OuterMethod);
            outer.Wait();
            WriteLine("Console app is stopping.");
        }

        // Methods to initiate a task and run another task within it
        static void OuterMethod() {
            WriteLine("Outer method starting...");

            // Example showing a Parent task might still finish before a Child task completes
            // var inner = Task.Factory.StartNew(InnerMethod);

            // Inner task needs to be defined
            var inner = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);
            
            WriteLine("Outer method finished.");
        }
        static void InnerMethod() {
            WriteLine("Inner method starting...");
            Thread.Sleep(2000);
            WriteLine("Inner method finished.");
        }
    }
}
