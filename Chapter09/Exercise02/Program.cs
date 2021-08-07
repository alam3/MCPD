using System;
using System.Collections.Generic;
using Shapes;
using static System.Console;
using System.Xml.Serialization;
using System.IO;
using static System.Environment;
using static System.IO.Path;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var listOfShapes = new List<Shape> {
                new Circle { Color = "Red", Radius = 2.5},
                new Rectangle { Color = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Color = "Green", Radius = 8.0 },
                new Circle { Color = "Purple", Radius = 12.3 },
                new Rectangle { Color = "Blue", Height = 45.0, Width = 18.0 }
            };

            // To serialize derived classes, used 'XmlInclude' attribute in base class
            XmlSerializer xs = new XmlSerializer(typeof(List<Shape>));
            string savePath = Combine(CurrentDirectory, "shapes.xml");
            // Serialize
            using(FileStream fileStream = File.Create(savePath)) {
                xs.Serialize(fileStream, listOfShapes);
            }

            // Deserialize
            WriteLine("Loading shapes from XML: ");
            using(FileStream xmlFile = File.Open(savePath, FileMode.Open)) {
                List<Shape> loadedShapes = (List<Shape>) xs.Deserialize(xmlFile);
                foreach (Shape shape in loadedShapes) {
                    WriteLine($"{shape.GetType().Name} is {shape.Color} and has an area of {shape.Area():N2}");
                }
            }

        }
    }
}
