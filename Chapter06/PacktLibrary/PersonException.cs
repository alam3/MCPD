using System;

namespace Packt.Shared {
    
    // Inheriting .NET Type
    public class PersonException : Exception {

        // Constructors are not inherited, so they must be explicitly
        // declared and explicitly call the base constructors.
        public PersonException() : base() { }
        public PersonException(string message) : base(message) { }
        public PersonException(string message, Exception innerException) 
                       : base (message, innerException) { }
    }
}