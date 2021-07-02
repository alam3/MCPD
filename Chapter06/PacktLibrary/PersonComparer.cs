using System.Collections.Generic;

namespace Packt.Shared {

    // Interfaces - IComparer to compare instances of a type
    // that does not implement IComparable itself
    public class PersonComparer : IComparer<Person> {
        public int Compare(Person x, Person y) {

            // Compare name lengths...
            int result = x.Name.Length.CompareTo(y.Name.Length);

            // ... if they are equal...
            if (result == 0) {
                // ... return comparison by Names...
                return x.Name.CompareTo(y.Name);
            } else {
                // ... otherwise return comparison by name length
                return result;
            }
        }
    }
}