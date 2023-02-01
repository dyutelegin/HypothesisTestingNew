using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Testing;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class KolmogorovSmirnovTestImplementation : IKolmogorovSmirnovTest
    {
        public string Calculate(double[] sample)
        {
            var distribution = UniformContinuousDistribution.Standard;
            var result = new KolmogorovSmirnovTest(sample, distribution);
            double pValue =  result.PValue;
            double staticValue = 0.05;
            string significant = " ";

            if (pValue >= staticValue)
            {
                significant += "Rozkład jest normalny, bo P-Value >= Poziomu istotności.";
            }
            else { significant += "Rozkład nie jest normalny, bo P-Value <= Poziomu istotności."; }

            return "<b>P-Value: </b>" + String.Format("{0:N6}", pValue) + " <b>Poziom istotności: </b>" + staticValue +
                "<br><b>Wynik: </b>" + significant;
        }
    }
}
