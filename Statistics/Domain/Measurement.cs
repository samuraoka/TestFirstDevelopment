using System;

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
    }
}
