using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class NormalTest : INormalTest
    {
        public string Calculate(double[] sample)
        {
            KolmogorovSmirnovTestImplementation kolmogorovSmirnovTest = new KolmogorovSmirnovTestImplementation();
            ShapiroWilkTestImplementation shapiroWilkTest = new ShapiroWilkTestImplementation();

            if (sample.Length < 50)
            {
                return "<b>Test Shapiro-Wilka: </b><br>" + shapiroWilkTest.Calculate(sample);
            }
            else { return "<b>Test Kolmogorowa-Smirnowa: </b><br>" + kolmogorovSmirnovTest.Calculate(sample); 
            }
        }
    }
}
