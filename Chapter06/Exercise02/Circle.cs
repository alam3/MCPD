using System;

public class Circle : Shape {
    public Circle(double diameter) {
        Height = diameter * 2;
        Width = diameter * 2;
        Area = Math.PI * Math.Pow(diameter, 2);
    }
}