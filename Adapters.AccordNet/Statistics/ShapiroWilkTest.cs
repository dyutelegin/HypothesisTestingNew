using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using Accord.Statistics.Testing;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class ShapiroWilkTestImplementation : IShapiroWilkTest
    {
        public string Calculate(double[] sample)
        {
            var result = new ShapiroWilkTest(sample);
            var pValue = result.PValue;
            double staticValue = 0.05;
            string significant = " ";

            if (pValue >= staticValue)
            {
                significant += "Rozkład jest normalny, bo P-Value >= Poziomu istotności.";
            } else { significant += "Rozkład nie jest normalny, bo P-Value <= Poziomu istotności."; }

            return "<b>P-Value: </b>" + String.Format("{0:N3}", pValue) + " <b>Poziom istotności: </b>" + staticValue +
                "<br><b>Wynik: </b>" + significant;
        }
    }
}
