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
            var list = new List<Measurement>();
            var document = XDocument.Load("Data.xml");

            foreach (var element in document.Element("Measurements").Elements())
            {
                var highValue = (double)element.Attribute("High");
                var lowValue = (double)element.Attribute("Low");
                var measurement = new Measurement();
                measurement.HighValue = highValue;
                measurement.LowValue = lowValue;
                list.Add(measurement);
            }
            var aggregator = new MeasurementAggregator(list);
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
