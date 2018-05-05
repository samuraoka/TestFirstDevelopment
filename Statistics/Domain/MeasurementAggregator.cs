using System.Collections.Generic;

namespace Domain
{
    public class MeasurementAggregator
    {
        private readonly IList<Measurement> _measurements;

        public MeasurementAggregator(IList<Measurement> measurements)
        {
            _measurements = measurements;
        }

        public IEnumerable<Measurement> Aggregate(AggregationSettings setting)
        {
            var partitions = setting.Grouper.Group(_measurements);
            foreach (var partition in partitions)
            {
                yield return setting.Calculator.Aggregate(partition);
            }
        }
    }

    public class AggregationSettings
    {
        public IGrouper Grouper { get; set; }
        public IAggregateCalculator Calculator { get; set; }
    }
}
