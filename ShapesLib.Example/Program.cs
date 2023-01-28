using System;
using System.Collections.Generic;
using ShapesLib;
using ShapesLib.Shapes;

namespace ShapesLibUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(new double[] { 6, 4, 5 });

            Circle circle = new Circle(5);

            List<IShape> shapes = new List<IShape>();
            shapes.Add(triangle);
            shapes.Add(circle);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }
        }
    }
}
