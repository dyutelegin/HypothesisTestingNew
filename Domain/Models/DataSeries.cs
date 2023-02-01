using System.Collections.Generic;
using System.Linq;

namespace HypothesisTestingNew.Domain.Models
{
    public class DataSeries
    {
        public double[] Values { get; }

        public DataSeries(IEnumerable<double> values)
        {
            Values = values.ToArray();
        }
    }
}
