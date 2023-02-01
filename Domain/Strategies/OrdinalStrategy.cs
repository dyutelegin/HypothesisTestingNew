using HypothesisTestingNew.Domain.Models;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using static HypothesisTestingNew.Domain.Constants;

namespace HypothesisTestingNew.Domain.Strategies
{
    public class OrdinalStrategy : IStrategy
    {
        public string ScaleMeasures => Constants.ScaleMeasures.Ordinal;
        private readonly IMedianaTest _medianaTest;
        private readonly IRandomnessTest _randomnessTest;
        private readonly IModaTest _modaTest;
        private readonly IBinomialTest _binomialTest;
        private readonly IProportionTest _proportionTest;
        private readonly ISampleSizeTest _sampleSizeTest;

        public OrdinalStrategy(IRandomnessTest randomnessTest, IMedianaTest medianaTest, IModaTest modaTest, IBinomialTest binomialTest, 
            IProportionTest proportionTest, ISampleSizeTest sampleSizaTest)
        {
            _randomnessTest = randomnessTest;
            _medianaTest = medianaTest;
            _modaTest = modaTest;
            _binomialTest = binomialTest;
            _proportionTest = proportionTest;
            _sampleSizeTest = sampleSizaTest;
        }

        public OutputData Execute(InputData input)
        {
            var resultValue = _randomnessTest.Calculate(input.xValues) 
                + "<br><li><b>Moda</b>: </li>" + _modaTest.Calculate(input.xValues)
                + "<br><li><b>Mediana</b>: </li>" + _medianaTest.Calculate(input.xValues)
                + "<br><li><b>Przedział ufności dla wskażnika struktury</b>: </li>" + _proportionTest.Calculate(input.xValues)
                + "<br><li><b>Wielkość próby dla wskażnika struktury</b>: </li>" + _sampleSizeTest.Calculate(input.xValues)
                + "<br><li><b>Test dla wskażnika struktury (Binomial Test)</b>: </li>" + _binomialTest.Calculate(input.xValues);
            var resultKey = Translations.RandomnessTest;
            return OutputData.Success(resultValue, resultKey);
        }
    }
}
