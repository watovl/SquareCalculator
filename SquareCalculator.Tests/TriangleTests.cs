using System;
using Xunit;

namespace SquareCalculator.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(2, 2, 3, 1.984313483298443)]
        [InlineData(5, 7, 8, 17.320508075688775)]
        public void CorrectCalculateSquare(double sideA, double sideB, double sideC, double expectedResult)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            double actualResult = triangle.Square();

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(6, 8, 10, 24)]
        public void CorrectCalculateSquareRightTriangle(double sideA, double sideB, double sideC, double expectedResult)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            double actualResult = triangle.Square();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void OverflowChecking()
        {
            double side = double.MaxValue;
            Triangle triangle = new Triangle(side, side, side);

            void Square() => triangle.Square();

            Assert.Throws<OverflowException>(Square);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(1, 7, 10)]
        public void NotExistChecking(double sideA, double sideB, double sideC)
        {
            void CreateTriangle() => new Triangle(sideA, sideB, sideC);

            Assert.Throws<ArgumentException>(CreateTriangle);
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 0, 3)]
        [InlineData(1, 2, 0)]
        public void ZeroSideChecking(double sideA, double sideB, double sideC)
        {
            void CreateTriangle() => new Triangle(sideA, sideB, sideC);

            Assert.Throws<ArgumentException>(CreateTriangle);
        }
    }
}
