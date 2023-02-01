using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Domain.Ports.Statistics
{
    public interface IShapiroWilkTest
    {
        string Calculate(double[] sample);
    }
}
