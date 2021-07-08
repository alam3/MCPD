using System;

public class Rectangle : Shape {
    public Rectangle(double height, double width) {
        Height = height;
        Width = width;
        Area = Height * Width;
    }
}