using ShapesLib.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesLib.Shapes
{
    public delegate double AreaMethodHandler();
    public class Triangle : IShape
    {
        public virtual string Name { get; } = "Triangle";
        public double[] Sides { get; }
        public double BaseSide { get; }
        public double Height { get; }

        AreaMethodHandler? DefaultAreaMethod;

        #region ctors

        public Triangle(double[] sides)
        {
            if (sides != null)
            {
                //if any of sides is negative number or zero
                if (sides.Any(x => x <= 0))
                {
                    throw new ArgumentException(ErrorMsg.SidesLengthAreNotPositive);
                }

                //if sides do not form a triangle
                if (sides[0] + sides[1] < sides[2] || sides[2] + sides[0] < sides[1] || sides[1] + sides[2] < sides[0])
                {
                    throw new ArgumentException(ErrorMsg.NotCorrectSidesLength);
                }
            }

            Sides = sides;

            //sets this method as default for calculating area in GetArea method
            DefaultAreaMethod += GetAreaBySides;
        }

        public Triangle(double baseSide, double height, double[] sides = null) : this(sides)
        {
            if (baseSide <= 0 || height <= 0)
            {
                throw new ArgumentException(ErrorMsg.BaseSideAndHeightAreNotPositive);
            }

            BaseSide = baseSide;
            Height = height;
        }

        #endregion

        /// <summary>
        /// Calculates area by default chosen method;
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            try
            {
                return (double)(DefaultAreaMethod?.Invoke());
            }
            catch (Exception ex)
            {
                throw new Exception("Not possible to use " + DefaultAreaMethod.Method.Name + " to calculate area: " + ex.Message);
            }
        }

        /// <summary>
        /// Heron's formula for calculating triangle area by 3 sides
        /// </summary>
        /// <returns></returns>
        private double GetAreaBySides()
        {
            if (Sides != null)
            {
                double perimeter = Sides.Sum() / 2;

                return Math.Sqrt(perimeter * (perimeter - Sides[0]) * (perimeter - Sides[1]) * (perimeter - Sides[2]));
            }
            else
            {
                throw new ArgumentNullException(ErrorMsg.SidesAreNotDefined);
            }
        }

        private double GetAreaByBaseAndHeight()
        {
            if (BaseSide <= 0 || Height <= 0)
            {
                throw new ArgumentException(ErrorMsg.BaseSideAndHeightAreNotPositive);
            }
            else
            {
                return 0.5 * BaseSide * Height;
            }
        }

        //check if triangle is rectangular 
        public bool IsRight()
        {
            if (Sides != null)
            {
                Array.Sort(Sides);

                return Math.Pow(Sides[2], 2) == Math.Pow(Sides[1], 2) + Math.Pow(Sides[0], 2);
            }
            else
            {
                throw new ArgumentNullException(ErrorMsg.SidesAreNotDefined);
            }
        }
    }
}
