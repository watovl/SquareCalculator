using System;
using System.Linq;

namespace SquareCalculator
{
    public class Triangle : GeometricFigure
    {
        private enum RightTriangle
        {
            Leg1 = 0,
            Leg2 = 1,
            Hypotenuse = 2
        }

        private const string NotPositiveErrorMsg = "Incorrect value of the side: the value of the sides must be positive";
        private const string NotExistErrorMsg = "Incorrect value of the side: a triangle with given sides does not exist";
        protected readonly double[] _sides;

        public Triangle(double sideA, double sideB, double sideC)
        {
            _sides = new double[] { sideA, sideB, sideC };
            if (!IsPositiveNumber())
            {
                throw new ArgumentException(NotPositiveErrorMsg);
            }
            Array.Sort(_sides);
            if (!IsExistTriangle())
            {
                throw new ArgumentException(NotExistErrorMsg);
            }
        }

        private bool IsPositiveNumber()
        {
            return _sides.All(side => side > 0.0);
        }

        private bool IsExistTriangle()
        {
            return _sides[0] + _sides[1] > _sides[2];
        }

        public override double Square()
        {
            double square= IsPythagoreanEquation() ? SquareRightTriangle() : SquareHeronFormula();
            return OverflowCheck(square);
        }

        protected bool IsPythagoreanEquation()
        {
            return _sides[(int)RightTriangle.Hypotenuse] * _sides[(int)RightTriangle.Hypotenuse] 
                == _sides[(int)RightTriangle.Leg1] * _sides[(int)RightTriangle.Leg1] 
                + _sides[(int)RightTriangle.Leg2] * _sides[(int)RightTriangle.Leg2];
        }

        protected double SquareRightTriangle()
        {
            return _sides[(int)RightTriangle.Leg1] * _sides[(int)RightTriangle.Leg2] * 0.5;
        }

        protected double SquareHeronFormula()
        {
            double semiPerimeter = _sides.Sum(side => side * 0.5);
            return Math.Sqrt(semiPerimeter * _sides
                .Select(side => semiPerimeter - side)
                .Aggregate((side, next) => side * next));
        }
    }
}
