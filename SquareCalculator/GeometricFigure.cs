using System;

namespace SquareCalculator
{
    public abstract class GeometricFigure
    {
        public abstract double Square();

        protected double OverflowCheck(double value)
        {
            if (double.IsInfinity(value))
            {
                throw new OverflowException();
            }
            return value;
        }
    }
}
