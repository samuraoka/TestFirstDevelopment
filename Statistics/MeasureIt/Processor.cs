using Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MeasureIt
{
    class Processor
    {
        private const int GROUP_SIZE = 2;

        public IEnumerable<Measurement> LoadAndAggregateData(XDocument document)
        {
            List<Measurement> measurements = Measurement.ParseMeasurements(document);
            return AggregateMeasurements(measurements);
        }

        private IEnumerable<Measurement> AggregateMeasurements(List<Measurement> measurements)
        {
            var aggregator = new MeasurementAggregator(measurements);
            var grouper = new SizeGrouper(GROUP_SIZE);
            var calculator = new AveragingCalculator();
            var result = aggregator.Aggregate(grouper, calculator);
            return result;
        }
    }
}
