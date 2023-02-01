using HypothesisTestingNew.Domain;
using HypothesisTestingNew.Domain.Models;

namespace HypothesisTestingNew.Infrastructure.Input
{
    public static class InputValidator
    {
        public static bool IsValid(string sampleType, double[] x)
        {
            if (sampleType == Constants.SamplesTypes.Independent)
            {
                return true;
            }

            return x.Length < 100;
        }
    }
}
