using Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MeasureIt
{
    class Processor
    {
        public IEnumerable<Measurement> LoadAndAggregateData(XDocument document)
        {
            List<Measurement> measurements = Measurement.ParseMeasurements(document);
            return AggregateMeasurements(measurements);
        }

        private IEnumerable<Measurement> AggregateMeasurements(List<Measurement> measurements)
        {
            var aggregator = new MeasurementAggregator(measurements);
            var grouper = new SizeGrouper(2);
            var calculator = new AveragingCalculator();
            var result = aggregator.Aggregate(grouper, calculator);
            return result;
        }
    }
}
