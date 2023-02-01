using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Domain.Ports.Statistics
{
    public interface ITTest
    {
        string Calculate(double[] sample);
    }
}
