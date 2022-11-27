using HypothesisTestingNew.Domain;
using HypothesisTestingNew.Domain.Models;

namespace HypothesisTestingNew.Infrastructure.Input
{
    public static class InputValidator
    {
        public static bool IsValid(string sampleType, DataSeries x)
        {
            if (sampleType == Constants.SamplesTypes.Independent)
            {
                return true;
            }

            return x.Values.Length < 100;
        }
    }
}
