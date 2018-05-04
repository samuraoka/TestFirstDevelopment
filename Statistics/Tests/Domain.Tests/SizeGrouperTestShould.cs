using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class SizeGrouperTestShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void ReceiveExceptionWhenInitializeSizeLessThanOne(int size)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new SizeGrouper(size);
            });
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(int.MaxValue)]
        public void ProperlyInitializedWhenSizeIsGreaterThanZero(int size)
        {
            // Act
            var grouper = new SizeGrouper(size);

            // Assert
            Assert.NotNull(grouper);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 1, 3)]
        [InlineData(3, 2, 2)]
        [InlineData(3, 3, 1)]
        [InlineData(5, 1, 5)]
        [InlineData(5, 2, 3)]
        [InlineData(5, 3, 2)]
        [InlineData(5, 4, 2)]
        [InlineData(5, 5, 1)]
        [InlineData(93, 7, 14)]
        public void GroupMeasurements(
            int measurementSize, int groupSize, int groupCount)
        {
            // Arrange
            var measurements = CreateMeasurements(measurementSize).ToList();
            var grouper = new SizeGrouper(groupSize);

            // Act
            var mg = grouper.Group(measurements);

            // Assert
            Assert.Equal(groupCount, mg.Count());
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 1, 3)]
        [InlineData(3, 2, 2)]
        [InlineData(3, 3, 1)]
        [InlineData(5, 1, 5)]
        [InlineData(5, 2, 3)]
        [InlineData(5, 3, 2)]
        [InlineData(5, 4, 2)]
        [InlineData(5, 5, 1)]
        [InlineData(93, 7, 14)]
        public void GroupMeasurementsCorrectSizeExceptLast(
            int measurementSize, int groupSize, int groupCount)
        {
            // Arrange
            var measurements = CreateMeasurements(measurementSize).ToList();
            var grouper = new SizeGrouper(groupSize);

            // Act
            var mg = grouper.Group(measurements);

            // Assert
            for (int i = 0; i < groupCount - 1; i += 1)
            {
                Assert.Equal(groupSize, mg.ElementAt(i).Count());
            }
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, 1)]
        [InlineData(2, 2, 2)]
        [InlineData(3, 1, 1)]
        [InlineData(3, 2, 1)]
        [InlineData(3, 3, 3)]
        [InlineData(5, 1, 1)]
        [InlineData(5, 2, 1)]
        [InlineData(5, 3, 2)]
        [InlineData(5, 4, 1)]
        [InlineData(5, 5, 5)]
        [InlineData(93, 7, 2)]
        public void GroupMeasurementsCorrectSizeJustLast(
            int measurementSize, int groupSize, int lastGroupSize)
        {
            // Arrange
            var measurements = CreateMeasurements(measurementSize).ToList();
            var grouper = new SizeGrouper(groupSize);

            // Act
            var mg = grouper.Group(measurements);

            // Assert
            Assert.Equal(lastGroupSize, mg.Last().Count());
        }

        private static IEnumerable<Measurement> CreateMeasurements(int measurementSize)
        {
            for (int i = 0; i < measurementSize; i += 1)
            {
                yield return new Measurement();
            }
        }
    }
}
