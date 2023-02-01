using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class BasicStatistics : IBasicStatistics
    {
        public string Calculate(double[] sample)
        {
            var randomnessTest = new RandomnessTest();
            var sampleTest = new SampleSizeTest();
            var modaTest = new ModaTest();
            var medianaTest = new MedianaTest();
            
            Array.Sort(sample);
            int count = sample.Length;
            double sum = randomnessTest.Sum(sample);
            double average = randomnessTest.Average(sample);
            double mediana = medianaTest.Calculate(sample);
            string moda = modaTest.Calculate(sample);
            double largest = sample[count - 1];
            double smallest = sample[0];
            double geometricMean = Math.Pow(Multiplication(sample), (1.0 / sample.Length));
            double range = largest - smallest;
            double variance = sampleTest.Variance(sample);
            double standardDevision = Math.Sqrt(variance);
            double sampleStandardDeviation = SampleStandardDeviation(sample);
            return "<b>Ilość: </b>" + count + " <b>Suma: </b>" + sum + " <b>Średnia: </b>" + String.Format("{0:N3}", average)
                + " <b>Mediana: </b>" + mediana + " <b>Moda: </b>" + moda
                + " <b>Największy: </b>" + largest + " <b>Najmniejszy: </b>" + smallest 
                + " <b>Średnia Geometryczna: </b>" + String.Format("{0:N3}", geometricMean) + " <b>Range: </b>" + range 
                + " <b>Variance: </b>" + String.Format("{0:N3}", variance) + " <b>Standard Devision: </b>" + String.Format("{0:N3}", standardDevision)
                + " <b>Sample Standard Deviation: </b>" + String.Format("{0:N3}", sampleStandardDeviation);
        }

        public double Multiplication(double[] sample)
        {
            double result = sample.Aggregate((x, y) => x * y);
            return result;
        }

        public double SampleStandardDeviation(double[] sample)
        {
            var sampleTest = new SampleSizeTest();
            double result = 0.0;
            double average = sampleTest.Average(sample);
            for (int i = 0; i < sample.Length; i++)
            {
                result += Math.Pow((sample[i] - average), 2);
            }

            return Math.Sqrt(result/(sample.Length - 1));
        }
    }
}
