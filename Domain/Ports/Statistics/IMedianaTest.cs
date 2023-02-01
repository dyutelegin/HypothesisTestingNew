using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Domain.Ports.Statistics
{
    public interface IMedianaTest
    {
        double Calculate(double[] sample);
    }
}
