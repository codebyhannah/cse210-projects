using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<Shape> shapes = new List<Shape>{new Square("Red", 2.5), new Rectangle("Orange", 2.5, 6), new Circle("Yellow", 2.5), new Triangle("Green", 4, 2.15)};
        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} {shape.GetType().Name} has an area of {shape.GetArea()}");
        }
        Console.WriteLine();
    }
}