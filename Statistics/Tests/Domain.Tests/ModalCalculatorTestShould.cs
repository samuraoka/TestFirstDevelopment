using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class ModalCalculatorTestShould
    {
        [Theory]
        [MemberData(nameof(GetMeasurements))]
        public void CalculateMode(IEnumerable<Measurement> measurements,
            double expectedModeHighValue, double expectedModeLowValue)
        {
            // Arrange
            var modalCalc = new ModalCalculator();

            // Act
            var actual = modalCalc.Aggregate(measurements);

            // Assert
            Assert.Equal(expectedModeHighValue, actual.HighValue);
            Assert.Equal(expectedModeLowValue, actual.LowValue);
        }

        public static IEnumerable<object[]> GetMeasurements()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    10.0, 1.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                    },
                    double.NaN, 1.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    10.0, double.NaN
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    10.0, 1.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    double.NaN, double.NaN
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                    },
                    double.NaN, double.NaN
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                    },
                    double.NaN, 1.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                    },
                    double.NaN, double.NaN
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    10.0, double.NaN
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    double.NaN, double.NaN
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    double.NaN, double.NaN
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                    },
                    10.0, 1.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                    },
                    5.0, 2.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                    },
                    2.0, 1.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    10.0, 4.0
                },
            };
        }
    }
}
