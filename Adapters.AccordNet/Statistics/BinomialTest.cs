using Accord.Statistics.Testing;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class BinomialTestImplementation : IBinomialTest
    {
        public string Calculate(double[] sample)
        {
            List<double> countN1 = new List<double>();

            foreach (double item in sample)
            {
                if (item > 0) countN1.Add(item);
            }

            int positiveCount = countN1.Count;

            BinomialTest test = new BinomialTest(
                successes: positiveCount, trials: sample.Length,
                hypothesizedProbability: 1.0 / 4.0,
                alternate: OneSampleHypothesis.ValueIsGreaterThanHypothesis);
            double pValue = test.PValue;

            return "<b>Sukcesy: </b>" + positiveCount + " <b>Iłość próby: </b>" + sample.Length + " <b>Hipotetyczne prawdopodobieństwo: </b> 25%" + "<br><b>P-Value: </b>" + String.Format("{0:N6}", pValue) + " <b>Wynik: </b>"+test.Significant;
        }
    }
}
