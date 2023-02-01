using HypothesisTestingNew.Domain.Models;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using static HypothesisTestingNew.Domain.Constants;

namespace HypothesisTestingNew.Domain.Strategies
{
    public class NominalSrategy: IStrategy
    {
        public string ScaleMeasures => Constants.ScaleMeasures.Nominal;
        private readonly IModaTest _modaTest;

        public NominalSrategy(IModaTest modaTest)
        {
            _modaTest = modaTest;
        }

        public OutputData Execute(InputData input)
        {
            string moda = _modaTest.Calculate(input.xValues);
            var resultKey = Translations.ModaTest;
            return OutputData.Success(moda, resultKey);
        }
    }
}
