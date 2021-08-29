using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncConsole {
    class Program {
        // static void Main(string[] args) { // Will not work with async methods!
        static async Task Main(string[] args) { // Allows Main() to work with async/await on C#7.1+
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://www.crunchyroll.com/");
            WriteLine("CrunchyRoll's home page has {0:N0} bytes.",
                response.Content.Headers.ContentLength);
        }
    }
}