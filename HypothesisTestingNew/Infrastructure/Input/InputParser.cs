using System;
using System.Globalization;
using System.Linq;
using HypothesisTestingNew.Domain.Models;

namespace HypothesisTestingNew.Infrastructure.Input
{
    public static class InputParser
    {
        public static bool TryParse(string val, out double[] XValues)
        {
            try
            {
                var sample = val
                    .Trim()
                    .Split(new[] { ',', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToDouble(x, CultureInfo.InvariantCulture))
                    .ToArray();

                XValues = sample;

                return sample.Length >= 5;
            }
            catch (Exception)
            {
                XValues = Array.Empty<double>();

                return false;
            }
        }
    }
}
