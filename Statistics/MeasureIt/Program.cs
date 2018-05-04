using System;
using System.Xml.Linq;

namespace MeasureIt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var proc = new Processor();
                var data = proc.LoadAndAggregateData(XDocument.Load("Data.xml"));
                foreach (var d in data)
                {
                    Console.WriteLine($"{d.LowValue}:{d.HighValue}");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
