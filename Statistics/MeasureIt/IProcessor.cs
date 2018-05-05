using Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MeasureIt
{
    public interface IProcessor
    {
        IEnumerable<Measurement> LoadAndAggregateData(XDocument document);
    }
}
