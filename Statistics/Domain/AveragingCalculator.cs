using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class AveragingCalculator
    {
        public Measurement Aggregate(IEnumerable<Measurement> measurements)
        {
            return new Measurement
            {
                HighValue = measurements.Average(m => m.HighValue),
                LowValue = measurements.Average(m => m.LowValue),
            };
        }
    }
}
