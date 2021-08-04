using System;
using System.Collections.Generic;
using System.Xml.Serialization; // To generate compact XML, e.g. setting a shortname

namespace Packt.Shared {
    public class Person {

        public Person() { }

        public Person(decimal initialSalary) {
            Salary = initialSalary;
        }

        [XmlAttribute("fname")] // For compact XML
        public string FirstName { get; set; }
        [XmlAttribute("lname")] // For compact XML
        public string LastName { get; set; }
        [XmlAttribute("dob")] // For compact XML
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
        protected decimal Salary { get; set; }
    }
}