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
            var grouper = new SizeGrouper(GROUP_SIZE);
            var calculator = new AveragingCalculator();
            var result = aggregator.Aggregate(grouper, calculator);
            return result;
        }
    }
}
