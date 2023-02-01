using System;

namespace SquareCalculator
{
    public class Circle : GeometricFigure
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double Square()
        {
            double square = Math.PI * _radius * _radius;
            return OverflowCheck(square);
        }
    }
}
