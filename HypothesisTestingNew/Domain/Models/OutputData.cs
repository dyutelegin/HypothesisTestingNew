using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypothesisTestingNew.Domain.Models
{
    public class OutputData
    {
        public bool HasError { get; set; }

        public string ErrorText { get; set; }

        public double PValue { get; set; }

        public string ResultKey { get; set; }

        private OutputData()
        {
        }

        public static OutputData Error(string error = "") =>
            new OutputData
            {
                HasError = true,
                ErrorText = error,
            };

        public static OutputData Success(double pValue, string resultKey = "") =>
            new OutputData
            {
                PValue = pValue,
                ResultKey = resultKey,
            };
    }
}
