using System;
using Xunit;

namespace Domain.Tests
{
    public class AggregationTypeTestShould
    {
        [Fact]
        public void RetrieveMeanTypeAsZero()
        {
            // Act
            var mean = AggregationType.Mean;

            // Assert
            // How to convert from System.Enum to base integer?
            // https://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            Assert.Equal(0, Convert.ToInt32(mean));
        }

        [Fact]
        public void RetrieveModeTypeAsOne()
        {
            // Act
            var mode = AggregationType.Mode;

            // Assert
            Assert.Equal(1, Convert.ToInt32(mode));
        }
    }
}
