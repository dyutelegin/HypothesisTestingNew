using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Domain.Ports.Statistics
{
    public interface IKolmogorovSmirnovTest
    {
        string Calculate(double[] sample);
    }
}
