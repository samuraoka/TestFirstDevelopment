using Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MeasureIt
{
    public abstract class ProcessorBase
    {
        public IEnumerable<Measurement> LoadAndAggregateData(XDocument document)
        {
            List<Measurement> measurements = Measurement.ParseMeasurements(document);
            return AggregateMeasurements(measurements);
        }

        protected abstract IEnumerable<Measurement> AggregateMeasurements(List<Measurement> measurements);
    }
}
