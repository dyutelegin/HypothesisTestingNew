using Accord;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class SampleSizeTest : ISampleSizeTest
    {
        public string Calculate(double[] sample)
        {
            var count = sample.Length;
            var z_score = 1.96;
            var average = Average(sample);
            var variance = Variance(sample);
            var standardDevision = Math.Sqrt(variance);
            var errorBound = (z_score*standardDevision)/(Math.Sqrt(count));
            var CL = 0.95;
            var nSqrt = (z_score * standardDevision) / errorBound;
            var n = Math.Pow(nSqrt, 2);
            return "<br><b>Standard devision: </b>" + String.Format("{0:N3}", standardDevision) +
                "<br><b>Average: </b>" + String.Format("{0:N3}", average) +
                "<br><b>Variance: </b>" + String.Format("{0:N3}", variance) +
                "<br><b>Error bound: </b>" + String.Format("{0:N3}", errorBound) +
                "<br><b>Confidence level: </b>" + CL + 
                "<br><b>n = </b>" + String.Format("{0:N3}", n);
        }

        private static double Sum(double[] sample)
        {
            double sum = 0;
            for (int i = 0; i < sample.Length; i++)
            {
                sum += sample[i];
            }
            return sum;
        }

        public double Average(double[] sample)
        {
            double sum = Sum(sample);
            double avg = (double)sum / sample.Length;
            return avg;
        }

        public double Variance(double[] sample)
        {
            if (sample.Length > 1)
            {
                double avg = Average(sample);
                double variance = 0.0;
                foreach (double value in sample)
                {
                    // Math.Pow to calculate variance
                    variance += Math.Pow((value - avg), 2.0);
                }
                return variance / (double) sample.Length; // For sample variance
            }
            else
            {
                return 0.0;
            }
        }
    }
}
