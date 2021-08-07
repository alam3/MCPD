namespace Shapes {
    public class Rectangle : Shape {
        public Rectangle() { }

        // public string Color { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public override double Area() => Height * Width;
    }
}