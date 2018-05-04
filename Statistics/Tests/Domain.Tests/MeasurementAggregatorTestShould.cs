using System.Collections.Generic;
using System.Xml.Linq;
using Xunit;

namespace Domain.Tests
{
    public class MeasurementAggregatorTestShould
    {
        [Fact]
        public void AggregateData()
        {
            // Arrange
            var measurements = Measurement.ParseMeasurements(XDocument.Load("Data.xml"));
            var aggregator = new MeasurementAggregator(measurements);
            var grouper = new SizeGrouper(2);
            var calculator = new AveragingCalculator();

            // Act
            var actual = aggregator.Aggregate(grouper, calculator);

            // Assert
            var expected = new List<Measurement>
            {
                new Measurement
                {
                    LowValue = 6.5,
                    HighValue = 10.5,
                },
                new Measurement
                {
                    LowValue = 7.5,
                    HighValue = 14,
                },
                new Measurement
                {
                    LowValue = 4.5,
                    HighValue = 13.5,
                },
                new Measurement
                {
                    LowValue = 3,
                    HighValue = 12,
                },
            };
            Assert.Equal(expected, actual);
        }
    }
}
