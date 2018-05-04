using Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MeasureIt
{
    class Processor
    {
        public IEnumerable<Measurement> LoadAndAggregateData(XDocument document)
        {
            var measurements = new List<Measurement>();

            foreach (var element in document.Element("Measurements").Elements())
            {
                var highValue = (double)element.Attribute("High");
                var lowValue = (double)element.Attribute("Low");
                var measurement = new Measurement
                {
                    HighValue = highValue,
                    LowValue = lowValue,
                };
                measurements.Add(measurement);
            }

            var aggregator = new MeasurementAggregator(measurements);
            var grouper = new SizeGrouper(2);
            var calculator = new AveragingCalculator();
            var result = aggregator.Aggregate(grouper, calculator);
            return result;
        }
    }
}
