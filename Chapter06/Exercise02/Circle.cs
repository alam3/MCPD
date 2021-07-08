using System;

public class Circle : Shape {
    public Circle(double diameter) {
        Height = diameter;
        Width = diameter;
        Area = Math.PI * Math.Pow(diameter, 2);
    }
}