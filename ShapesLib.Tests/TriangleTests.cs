using ShapesLib.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShapesLib.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void Ctor_NegativeOrZeroHeightBase()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(0, 1.5));
            Assert.Throws<ArgumentException>(() => new Triangle(-1, -2));
            Assert.Throws<ArgumentException>(() => new Triangle(2, -3.2, null));
        }

        [Fact]
        public void Ctor_PositiveHeightAndBase()
        {
            //area calculatings are correct
            Circle testCircle = new Circle(5.3);
            var area = Math.PI * Math.Pow(5.3, 2);
            Assert.Equal(testCircle.GetArea(), area);

            //no exception thrown
            var exception = Record.Exception(() => new Circle(8));
            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_SidesDontFormATriangle()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 10, 9, 0.2 }));
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 10, 0.001, 25 }));
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 0.374, 9, 0.45 }));
        }

        [Fact]
        public void Ctor_SidesNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 0, 1, 2 }));
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 2, 0, 3.4 }));
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 0.3, 0.4, 0 }));

            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { -10, 1, 2 }));
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 2, -10, 3.4 }));
            Assert.Throws<ArgumentException>(() => new Triangle(new double[] { 0.3, 0.4, -10 }));
        }

        [Fact]
        public void GetArea_SidesAreNotDefined()
        {
            //triangle were defined by height and base side, so not
            //possible to calculate area by 3 sides
            Triangle testTriangle = new Triangle(2, 5.6);

            Assert.Throws<Exception>(() => testTriangle.GetArea());
        }

        [Fact]
        public void GetArea_CorrectAreaResult()
        {
            double a = 3.9;
            double b = 4;
            double c = 2.91;

            double perimeter = (a + b + c) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));

            Triangle testTriangle = new Triangle(new double[] { a, b, c });

            Assert.Equal(testTriangle.GetArea(), area);
        }

        [Fact]
        public void IsRight_CorrectResult()
        {
            //if sides are not defined
            Triangle testNullSides = new Triangle(2, 5.6);
            Assert.Throws<ArgumentNullException>(() => testNullSides.IsRight());

            //if result is correct
            Triangle testIsRight = new Triangle(new double[] { 3, 4, 5 });
            Assert.True(testIsRight.IsRight());

            Triangle testIsNotRight = new Triangle(new double[] { 3.1, 4.9, 7.0001 });
            Assert.False(testIsNotRight.IsRight());
        }
    }
}
