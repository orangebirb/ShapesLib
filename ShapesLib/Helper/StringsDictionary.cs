using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesLib.Helper
{
    public static class ErrorMsg
    {
        static public readonly string SidesLengthAreNotPositive = "Length of sides can't be negative or zero";
        static public readonly string NotCorrectSidesLength = "Length of sides is not correct for a triangle";
        static public readonly string BaseSideAndHeightAreNotPositive = "Base side and height can't be negative or zero";
        static public readonly string SidesAreNotDefined = "Sides are not defined";

        static public readonly string RadiusIsNotPositive = "Radius can't be negative or zero";
    }
}
