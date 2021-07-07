using System;
using static System.Console;

namespace Packt.Shared {
    // Inheriting from another class (Person)

    public class Employee : Person {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        // Hiding inherited members, in this case 'WriteToConsole()'
        // Note how this method is called instead of the one in 'Person'
        public void WriteToConsole() {
            WriteLine("{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
                      arg0: Name,
                      arg1: DateOfBirth,
                      arg2: HireDate);
        }
    }
}