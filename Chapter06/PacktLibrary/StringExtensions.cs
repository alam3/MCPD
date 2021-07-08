using System.Text.RegularExpressions;

namespace Packt.Shared {

    // Extending an uninheritable (sealed) .NET type
    public class StringExtensions {
        public static bool IsValidEmail(string input) {
            // Use regex to validate an email address.
            return Regex.IsMatch(input,
                                 @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}