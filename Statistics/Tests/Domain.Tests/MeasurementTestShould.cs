using Xunit;

namespace Domain.Tests
{
    public class MeasurementTestShould
    {
        [Fact]
        public void GetHighValueAsDouble()
        {
            // Arrange
            var measurement = new Measurement();

            // Act
            var highValue = measurement.HighValue;

            // Assert
            Assert.Equal(0.0, highValue, 15);
        }

        [Fact]
        public void SetHighValueAsDouble()
        {
            // Arrange
            var measurement = new Measurement();

            // Act
            measurement.HighValue = 12.345678910111213141516;

            // Assert
            Assert.Equal(12.345678910111213, measurement.HighValue, 15);
        }

        [Fact]
        public void GetLowValueAsDouble()
        {
            // Arrange
            var measurement = new Measurement();

            // Act
            var lowValue = measurement.LowValue;

            // Assert
            Assert.Equal(0.0, lowValue, 15);
        }

        [Fact]
        public void SetLowValueAsDouble()
        {
            // Arrange
            var measurement = new Measurement();

            // Act
            measurement.LowValue = 12.345678910111213141516;

            // Assert
            Assert.Equal(12.345678910111213, measurement.LowValue, 15);
        }
    }
}
