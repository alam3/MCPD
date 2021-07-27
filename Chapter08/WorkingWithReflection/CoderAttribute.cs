using System;

namespace Packt.Shared {
    // Creating a custom attribute that decorates classes or methods with properties to store the name of a coder

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CoderAttribute : Attribute {
        public string Coder { get; set; }
        public DateTime LastModified { get; set; }
        public CoderAttribute(string coder, string lastModified) {
            Coder = coder;
            LastModified = DateTime.Parse(lastModified);
        }
    }
}