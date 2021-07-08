using System.Text.RegularExpressions;

namespace Packt.Shared {

    // Extending an uninheritable (sealed) .NET type
    // public class StringExtensions {
    //     public static bool IsValidEmail(string input) {
    //         // Use regex to validate an email address.
    //         return Regex.IsMatch(input,
    //                              @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
    //     }
    // }


    // Using Extension Methods to reduce code and simplify usage
    // Add 'static' to class and 'this' before 'string input'
    // these changes tell the compiler to treat the method as
    // extending the 'string' type
    public static class StringExtensions {
        public static bool IsValidEmail(this string input) {
            // Use regex to validate an email address.
            return Regex.IsMatch(input,
                                 @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}