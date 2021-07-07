using System;

namespace Packt.Shared {
    // Inheriting from another class (Person)

    public class Employee : Person {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }
    }
}