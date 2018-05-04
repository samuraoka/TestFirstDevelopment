using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Tests
{
    public class ModalCalculator : IAggregateCalculator
    {
        public Measurement Aggregate(IEnumerable<Measurement> measurements)
        {
            return new Measurement
            {
                HighValue = CalculateMode(measurements, m => m.HighValue),
                LowValue = CalculateMode(measurements, m => m.LowValue),
            };
        }

        private double CalculateMode(IEnumerable<Measurement> measurements,
            Func<Measurement,double> keySelector)
        {
            var valueQuery = measurements.GroupBy(keySelector)
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    Value = g.Key,
                    Count = g.Count(),
                });
            var valueOne = valueQuery.FirstOrDefault();
            var valueTwo = valueQuery.Skip(1).FirstOrDefault();

            double value = double.NaN;
            if (valueOne == null)
            {
                value = double.NaN;
            }
            else if (valueTwo == null)
            {
                value = valueOne.Value;
            }
            else if (valueOne.Count == valueTwo.Count)
            {
                value = double.NaN;
            }
            else
            {
                value = valueOne.Value;
            }

            return value;
        }
    }
}
