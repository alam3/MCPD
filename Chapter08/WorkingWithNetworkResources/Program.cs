using System;
using static System.Console;
using System.Net;
using System.Net.NetworkInformation; // For pinging a server

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


            // Pinging a server using imported System.Net.NetworkInformation
            try {
                var ping = new Ping();
                WriteLine("Pinging server. Please wait...");
                PingReply reply = ping.Send(uri.Host);
                WriteLine($"{uri.Host} was pinged and replied: {reply.Status}");
                if (reply.Status == IPStatus.Success) {
                    WriteLine("Reply from {0} took {1:N0}ms", reply.Address, reply.RoundtripTime);
                }
            } catch (Exception ex) {
                WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
            }
        }
    }
}
