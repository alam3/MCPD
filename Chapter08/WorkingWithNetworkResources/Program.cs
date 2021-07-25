using System;
using static System.Console;
using System.Net;

namespace WorkingWithNetworkResources {
    class Program {
        static void Main(string[] args) {
            // .NET Types for Network Resources
            // Deconstructing the web address into its URI components
            Write("Enter a valid web address: ");
            string url = ReadLine();
            if (string.IsNullOrWhiteSpace(url)) {
                url = "https://world.episerver.com/cms/?q=pagetype";
            }

            Uri uri = new Uri(url); // The URI type breaks down the URL to its URI components
            WriteLine($"URL: {url}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");


            // Get the IP address for the website
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} has the following IP addresses:");
            foreach (IPAddress address in entry.AddressList) {
                WriteLine($" {address}");
            }
        }
    }
}
