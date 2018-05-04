using Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MeasureIt
{
    class Processor
    {
        public IEnumerable<Measurement> LoadAndAggregateData()
        {
            var list = new List<Measurement>();
            var document = XDocument.Load("Data.xml");

            foreach (var element in document.Element("Measurements").Elements())
            {
                var highValue = (double)element.Attribute("High");
                var lowValue = (double)element.Attribute("Low");
                var measurement = new Measurement
                {
                    HighValue = highValue,
                    LowValue = lowValue,
                };
                list.Add(measurement);
            }

            var aggregator = new MeasurementAggregator(list);
            var grouper = new SizeGrouper(2);
            var calculator = new AveragingCalculator();
            var result = aggregator.Aggregate(grouper, calculator);
            return result;
        }
    }
}
