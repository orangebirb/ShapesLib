using ShapesLib.Helper;
using ShapesLib.Shapes;
using System;
using Xunit;

namespace ShapesLib.Tests
{
    public class CircleTests
    {
        [Fact]
        public void Ctor_NegativeOrZeroRadius()
        {
            Assert.Throws<ArgumentException>(() => new Circle(0));
            Assert.Throws<ArgumentException>(() => new Circle(-1));
        }

        [Fact]
        public void Ctor_PositiveRadius()
        {
            //no exception thrown
            var exception = Record.Exception(() => new Circle(8));
            Assert.Null(exception);
        }

        [Fact]
        public void GetArea_CorrectAreaResult()
        {
            //area calculatings are correct
            Circle testCircle = new Circle(5.3);
            var area = Math.PI * Math.Pow(5.3, 2);

            Assert.Equal(testCircle.GetArea(), area);

        }
    }
}
