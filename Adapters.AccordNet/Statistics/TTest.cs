using Accord.Statistics.Testing;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class TTestImplementation : ITTest
    {
        public string Calculate(double[] sample)
        {
            var basicStatistic = new BasicStatistics();
            double geometricMean = Math.Pow(basicStatistic.Multiplication(sample), (1.0 / sample.Length)); 
            TTest ttestLeft = new TTest(sample, geometricMean, OneSampleHypothesis.ValueIsSmallerThanHypothesis);
            double pValueLeft = ttestLeft.PValue;
            TTest ttesRight = new TTest(sample, geometricMean, OneSampleHypothesis.ValueIsGreaterThanHypothesis);
            double pValueRight = ttesRight.PValue;
            TTest ttesTwoTail = new TTest(sample, geometricMean, OneSampleHypothesis.ValueIsDifferentFromHypothesis);
            double pValueTwoTail = ttesTwoTail.PValue;
            double statistic = ttesRight.Statistic;
            return "<b>P-Value dla Left‐tailed: </b>" + String.Format("{0:N6}", pValueLeft) + " <b>P-Value dla Right‐tailed: </b>" + String.Format("{0:N6}", pValueRight) +
                " <b>P-Value dla Twot‐tailed: </b>" + String.Format("{0:N6}", pValueTwoTail) + " <br><b>Test statistic: </b>" + String.Format("{0:N6}", statistic);
        }
    }
}
