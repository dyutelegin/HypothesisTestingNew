using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class ModaTest : IModaTest
    {
        public string Calculate(double[] sample)
        {
            // Check if the array has values        
            if (sample == null || sample.Length == 0)
                throw new ArgumentException("Array is empty.");

            // Convert the array to a Lookup
            var dictSource = sample.ToLookup(x => x);

            // Find the number of modes
            var numberOfModes = dictSource.Max(x => x.Count());

            // Get only the modes
            var modes = dictSource.Where(x => x.Count() == numberOfModes).Select(x => x.Key);

            return String.Join(" ", modes);
        }
    }
}
