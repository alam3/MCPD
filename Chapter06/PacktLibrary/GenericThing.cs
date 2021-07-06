using System;

namespace Packt.Shared {
    public class GenericThing<T> where T : IComparable {
        // Generics allow passing of types as paramenters
        // Second, a generic type example. 'T' represents a generic type
        public T Data = default(T);
        public string Process(T input) {
            if (Data.CompareTo(input) == 0) {
                return "Data and input are the same.";
            } else {
                return "Data and input are NOT the same.";
            }
        }
    }
}