using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypothesisTestingNew.Domain.Statistics
{
    public class HypothesisHelper
    {
        public static bool IsHypothesisTrue(double pValue, double significance) => pValue >= significance;
    }
}
