using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class AveragingCalculatorTestShould
    {
        [Theory]
        [MemberData(nameof(GetMeasurements))]
        public void CalculateAverage(IEnumerable<Measurement> measurements,
            double expectedHighValue, double expectedLowValue)
        {
            // Arrange
            var averageCalc = new AveragingCalculator();

            // Act
            var actual = averageCalc.Aggregate(measurements);

            // Assert
            Assert.Equal(expectedHighValue, actual.HighValue, 15);
            Assert.Equal(expectedLowValue, actual.LowValue, 15);
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
                    6.75, 2.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                    },
                    5.6666666666666667, 1.3333333333333333
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    8.3333333333333333, 2.3333333333333333
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    7.3333333333333333, 2.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    5.6666666666666667, 2.3333333333333333
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                    },
                    7.5, 1.5
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                    },
                    6.0, 1.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                    },
                    3.5, 1.5
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 10.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    10.0, 2.5
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 5.0, LowValue = 2.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    7.5, 3.0
                },
                new object[]
                {
                    new List<Measurement>
                    {
                        new Measurement() {HighValue = 2.0, LowValue = 1.0},
                        new Measurement() {HighValue = 10.0, LowValue = 4.0},
                    },
                    6.0, 2.5
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
