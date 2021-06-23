using System;
using static System.Console;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Instrumenting {
    class Program {
        static void Main(string[] args) {
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));
            Trace.AutoFlush = true;
            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json",
                                                                 optional: true,
                                                                 reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(displayName: "TraceSwitch",
                                     description: "This switch is set via a JSON config.");
            configuration.GetSection("TraceSwitch").Bind(ts);
            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }
    }
}
