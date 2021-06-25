using System;
using System.Collections.Generic;

namespace Packt.Shared {
    public class ThingOfDefaults {
        // setting all types to defaults on construction
        public int Population;
        public DateTime When;
        public string Name;
        public List<Person> People;
        public ThingOfDefaults() {
            // Pre-C#7.1, compiler could not implicitly tell type
            // Population = default(int);
            // When = default(DateTime);
            // Name = default(string);
            // People = default(List<Person>);

            // Now, compiler can determine the type
            Population = default;
            When = default;
            Name = default;
            People = default;
        }
    }
}