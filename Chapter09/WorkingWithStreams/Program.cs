using System;
using static System.Console;
using System.IO;
using System.Xml;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithStreams {
    class Program {
        static void Main(string[] args) {
            // Examples of Stream manipulation - writing text to a text stream
            WorkWithText();
        }

        // Define an array of Viper pilot call signs
        static string[] callsigns = new string[] {"Husker", "Starbuck", "Apollo", "Boomer",
                                                  "Bulldog", "Athena", "Helo", "Racetrack"};
        static void WorkWithText() {
            // file to write to
            string textFile = Combine(CurrentDirectory, "streams.txt");
            // create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);
            // enumerate the strings, writing each one to the stream on a separate line
            foreach (string item in callsigns) {
                text.WriteLine(item);
            }
            text.Close(); // release resources
            // output the contents of the file
            WriteLine("{0} contains {1:N0} bytes.", textFile, new FileInfo(textFile).Length);
            WriteLine(File.ReadAllText(textFile));
        }
    }
}
