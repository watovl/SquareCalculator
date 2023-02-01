using System;
using Xunit;

namespace SquareCalculator.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1.0, Math.PI)]
        [InlineData(10.0, 314.1592653589793)]
        [InlineData(3000.0, 28274333.882308137)]
        public void CorrectCalculateSquare(double radius, double expectedResult)
        {
            Circle circle = new Circle(radius);

            double actualResult = circle.Square();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void OverflowChecking()
        {
            const double radius = double.MaxValue;
            Circle circle = new Circle(radius);

            void Square() => circle.Square();

            Assert.Throws<OverflowException>(Square);
        }
    }
}
