using Accord.Statistics.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System.Linq;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class HistogramTest: IHistogramTest
    {
        public string Calculate(double[] sample)
        {
            var result  = new List<string>();            

            sample
                .GroupBy(i => i)
                .Select(g => new {
                    Item = g.Key,
                    Count = g.Count()
                    })
                .OrderBy(g => g.Item)
                .ToList()
                .ForEach(g => {
                    string line = String.Format("{0} wystąpił {1} raz/razy", g.Item, g.Count);
                    result.Add(line);
                              });


            return String.Join("<br>", result);
        }
    }
}
