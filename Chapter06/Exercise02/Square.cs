using System;

public class Square : Shape {
    public Square(double side) {
        Height = side;
        Width = side;
        Area = Height * Width;
    }
}