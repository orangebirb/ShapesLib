using ShapesLib.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesLib.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException(ErrorMsg.RadiusIsNotPositive);
            }

            Radius = radius;
        }

        public double GetArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }
    }
}
