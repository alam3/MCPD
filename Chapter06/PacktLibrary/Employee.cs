using System;
using static System.Console;

namespace Packt.Shared {
    // Inheriting from another class (Person)

    public class Employee : Person {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        // Hiding inherited members, in this case 'WriteToConsole()'
        // Note how this method is called instead of the one in 'Person'
        public new void WriteToConsole() {
            WriteLine("{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
                      arg0: Name,
                      arg1: DateOfBirth,
                      arg2: HireDate);
        }

        // Overriding parent methods, in this case 'ToString()'
        // Inheritance and overriding can be prevented with the 'sealed' keyword
        // public override string ToString() {
        //     // 'base' gives access to the parent class members
        //     return $"{Name} is a {base.ToString()}";
        // }
        
        // Non-polymorphic inheritance vs. Polymorphic inheritance
        public override string ToString() {
            return $"{Name}'s code is {EmployeeCode}";
        }
    }
}