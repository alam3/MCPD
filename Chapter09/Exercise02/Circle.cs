using System;

namespace Shapes {
    public class Circle : Shape {
        public Circle() { }

        // public string Color { get; set; }
        public double Radius { get; set; }

        public override double Area() => Math.PI * Math.Pow(Radius, 2.0D);
    }
}