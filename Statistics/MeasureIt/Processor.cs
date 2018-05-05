using Domain;
using System.Collections.Generic;

namespace MeasureIt
{
    class Processor : ProcessorBase, IProcessor
    {
        private const int GROUP_SIZE = 2;

        protected override IEnumerable<Measurement> AggregateMeasurements(List<Measurement> measurements)
        {
            var aggregator = new MeasurementAggregator(measurements);
            var setting = new AggregationSettings
            {
                Grouper = new SizeGrouper(GROUP_SIZE),
                Calculator = new AveragingCalculator(),
            };
            var result = aggregator.Aggregate(setting);
            return result;
        }
    }
}
