using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class ProportionTest : IProportionTest
    {
        public string Calculate(double[] sample)
        {
            List<double> countN1 = new List<double>();

            foreach (double item in sample)
            {
                if (item > 0) countN1.Add(item);
            }
            double count = sample.Length; //Sample size
            double x = countN1.Count; //Number in the sample with the result or finding in question
            var CL = "95 %"; //Confidence level
            double P =  x / count;
            double SEM = Math.Sqrt(x*(count - x)/(Math.Pow(count, 3)));
            double lowerBound = P - (1.9600 * SEM);
            double upperBound = P + (1.9600 * SEM);

            return "<b>Odsetek pozytywnych wyników: P = x/N: </b>" + String.Format("{0:N4}", P) + " <br><b>Błąd standardowy średniej = SEM = √x(N-x)/N3 =</b> " + String.Format("{0:N4}", SEM) +
                "<br><b>Standardowe normalne odchylenie dla Zα</b>: 1.9600" + " <br><b>Lower bound = P - (Zα*SEM) = </b> " +
                String.Format("{0:N4}", lowerBound) + " <br><b>Upper bound = P + (Zα*SEM) = </b> " + String.Format("{0:N4}", upperBound);
        }
    }
}
