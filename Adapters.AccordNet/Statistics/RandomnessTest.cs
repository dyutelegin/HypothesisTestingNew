using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using Accord.Statistics.Testing;
using MathNet.Numerics;
using System.Transactions;
using static HypothesisTestingNew.Domain.Constants;
using Accord.Statistics.Distributions.Univariate;
using System.Linq;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class RandomnessTest : IRandomnessTest
    {
        public string Calculate(double[] sample)
        {
            double geometricMean = Math.Pow(Multiplication(sample), (1.0 / sample.Length));
            double pValue = new TTest(sample, geometricMean, OneSampleHypothesis.ValueIsSmallerThanHypothesis).PValue;
            List<double> countN1 = new List<double>();

            double average = Average(sample);

            foreach (double item in sample) {
                if(item < average) countN1.Add(item);
            }

            int R = countN1.Count;

            string conclusion = ""; //TODO constant translation
            //"Very strong evidence against randomness (trend or seasonality)"
            if (pValue < 0.01) { conclusion += "Bardzo mocne dowody przeciwko losowości"; }
            //"Moderate evidence against randomness"
            else if (pValue >= 0.01 && pValue < 0.05)
            { conclusion += "Umiarkowane dowody przeciwko losowości"; }
            //"Suggestive evidence against randomness"
            else if (pValue >= 0.05 && pValue < 0.1) {conclusion = "Sugestywne dowody przeciwko losowości"; }
            //"Little or no real evidences against randomness"
            else if (pValue >= 0.10)
            { conclusion += "Niewiele lub brak  dowodów przeciwko losowości"; }
            //"Strong evidence against randomness (trend or seasonality exists)"
            else { conclusion += "Strong evidence against randomness (trend or seasonality exists)"; }

            return "<b>Liczba serii: </b> " + R +
                "<br><b>Średnia: </b> " + String.Format("{0:N3}", average) +
                "<br><b>pValue: </b> " + String.Format("{0:N3}", pValue) + 
                "<br><b>Wniosek: </b> " + conclusion +
                "<br>Summa: " + String.Format("{0:N3}", Sum(sample));
        }

        public double Sum(double[] sample)
        {
            double result = 0;

            for (int i = 0; i < sample.Length; i++)
            {
                result += sample[i];
            }

            return result;
        }

        public double Multiplication(double[] sample)
        {
            double result = sample.Aggregate((x, y) => x * y);
            return result;
        }

        public double Average(double[] customerssalary)
        {
            double sum = Sum(customerssalary);
            double result = sum / customerssalary.Length;
            return result;
        }
    }
}
