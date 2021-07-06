using System;

namespace Packt.Shared {
    public class Thing {

        // Generics allow passing of types as paramenters
        // First, an example of a non-generic type
        public object Data = default(object);
        public string Process(object input) {
            if (Data == input) {
                return "Data and input are the same.";
            } else {
                return "Data and input are NOT the same.";
            }
        }
    }
}