using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Domain
{
    public class Measurement : IEquatable<Measurement>
    {
        public double HighValue { get; set; }
        public double LowValue { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Measurement);
        }

        public bool Equals(Measurement other)
        {
            return other != null &&
                   HighValue == other.HighValue &&
                   LowValue == other.LowValue;
        }

        public override int GetHashCode()
        {
            var hashCode = 375971584;
            hashCode = hashCode * -1521134295 + HighValue.GetHashCode();
            hashCode = hashCode * -1521134295 + LowValue.GetHashCode();
            return hashCode;
        }

        public static List<Measurement> ParseMeasurements(XDocument document)
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

            return measurements;
        }

    }
}
