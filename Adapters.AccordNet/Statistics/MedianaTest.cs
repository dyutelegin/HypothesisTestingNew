using HypothesisTestingNew.Domain.Ports.Statistics;
using MathNet.Numerics.Statistics;
using Accord.Statistics;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class MedianaTest : IMedianaTest
    {
        public double Calculate(double[] sample)
        {
            if (sample == null || sample.Length == 0)
                throw new System.Exception("Median of empty array not defined.");

            double median = sample.Median();
            return median;
        }
    }
}
