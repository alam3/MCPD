using System.Text.RegularExpressions;

namespace Packt.Shared {
    public static class StringExtensions {
        public static bool IsValidXmlTag(this string input) {
            return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }

        public static bool IsValidPassword(this string input) {
            // '{8, }' means a minimum of 8 valid characters
            return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
        }

        public static bool IsValidHex(this string input) {
            // '{3}' and '{6}' specify 3 valid characters and 6 valid characters respectively
            // '|' makes this an OR choice
            return Regex.IsMatch(input, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }
}
