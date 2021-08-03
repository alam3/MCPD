using System;
using static System.Console;
using System.IO;
using System.Xml;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression; // For compressing streams

namespace WorkingWithStreams {
    class Program {
        static void Main(string[] args) {
            // Examples of Stream manipulation - writing text to a text stream
            // WorkWithText();
            WorkingWithXml();
            // WorkingWithCompression();
            WorkingWithBrotliCompression();
            WorkingWithBrotliCompression(false); // fallback to GZIP
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

        // Writing to XML Streams - write each callsign as an element in a single XML file
        static void WorkingWithXml() {
            // Properly disposing of unmanaged resources
            FileStream xmlFileStream = null;
            XmlWriter xml = null;
            try {
                string xmlFile = Combine(CurrentDirectory, "streams.xml");
                // create filestream
                // FileStream xmlFileStream = File.Create(xmlFile); // old, before proper disposal
                xmlFileStream = File.Create(xmlFile);
                // wrap in an XML writer helper
                //XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true }); // old, before proper disposal
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

                // write the XML declaration
                xml.WriteStartDocument();
                // write a root element
                xml.WriteStartElement("callsigns");
                // enumerate the strings writing each one to the stream, one at a time
                foreach (string item in callsigns) {
                    xml.WriteElementString("callsign", item);
                }
                // write the close root element
                xml.WriteEndElement();
                // close helper and stream
                xml.Close();
                xmlFileStream.Close();
                // output contents of the file
                WriteLine("{0} contains {1:N0} bytes.", xmlFile, new FileInfo(xmlFile).Length);
                WriteLine(File.ReadAllText(xmlFile));
            } catch(Exception ex) {
                // if the path doesn't exist, the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            } finally {
                // Dispose of unmanaged resources once done using them
                if (xml != null) {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }
                if (xmlFileStream != null) {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed.");
                }
            }
        }

        // Stream compression; import System.IO.Compression.
        static void WorkingWithCompression() {
            // Output location
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");
            FileStream gzipFile = File.Create(gzipFilePath);
            // The FileStream
            using (GZipStream compressor = new GZipStream(gzipFile, CompressionMode.Compress)) {
                // The Writer
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor)) {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");
                    foreach (string item in callsigns) {
                        xmlGzip.WriteElementString("callsign", item);
                    }
                    // The call to WriteEndElement is not necessary because when XmlWriter disposes
                    // it will automatically end any elements of any depth (from 'using() {}')
                }
            } // closes the underlying FileStream

            // output all contents for the compressed file
            WriteLine("{0} contains {1:N0} bytes.", gzipFilePath, new FileInfo(gzipFilePath).Length);
            WriteLine($"The compressed contents: ");
            WriteLine(File.ReadAllText(gzipFilePath));
            // read a compressed file
            WriteLine("Reading the compressed XML file:");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);
            using (GZipStream decompressor = new GZipStream(gzipFile, CompressionMode.Decompress)) {
                using (XmlReader reader = XmlReader.Create(decompressor)) {
                    while (reader.Read()) { // read the next XML node
                        // check if we are on an element node named callsign
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign")) {
                            reader.Read(); // move to the text inside element
                            WriteLine($"{reader.Value}"); // Read the value of the text
                        }
                    }
                }
            }
        }


        // Brotli Algorithm Compression
        static void WorkingWithBrotliCompression(bool useBrotli = true) {
            string fileExt = useBrotli ? "brotli" : "gzip"; // determines which compression to use
            // Output location
            string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");
            FileStream file = File.Create(filePath);
            // The FileStream
            
            // Choose compression type
            Stream compressor;
            if (useBrotli) {
                compressor = new BrotliStream(file, CompressionMode.Compress);
            } else {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }

            using (compressor) {
                // The Writer
                using (XmlWriter xml = XmlWriter.Create(compressor)) {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns");
                    foreach (string item in callsigns) {
                        xml.WriteElementString("callsign", item);
                    }
                    // The call to WriteEndElement is not necessary because when XmlWriter disposes
                    // it will automatically end any elements of any depth (from 'using() {}')
                }
            } // closes the underlying FileStream

            // output all contents for the compressed file
            WriteLine("{0} contains {1:N0} bytes.", filePath, new FileInfo(filePath).Length);
            WriteLine($"The compressed contents: ");
            WriteLine(File.ReadAllText(filePath));
            // read a compressed file
            WriteLine("Reading the compressed XML file:");
            file = File.Open(filePath, FileMode.Open);
            // Selecting the decompressor
            Stream decompressor;
            if (useBrotli) {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            } else {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }

            using (decompressor) {
                using (XmlReader reader = XmlReader.Create(decompressor)) {
                    while (reader.Read()) { // read the next XML node
                        // check if we are on an element node named callsign
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign")) {
                            reader.Read(); // move to the text inside element
                            WriteLine($"{reader.Value}"); // Read the value of the text
                        }
                    }
                }
            }
        }
    }
}
