using HypothesisTestingNew.Domain.Models;
using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using static HypothesisTestingNew.Domain.Constants;
using static System.Net.Mime.MediaTypeNames;

namespace HypothesisTestingNew.Domain.Strategies
{

    public class IntervalStrategy : IStrategy
    {
        public string ScaleMeasures => Constants.ScaleMeasures.Interval;

        private readonly IShapiroWilkTest _shapiroWilkTest;
        private readonly ISampleSizeTest _sampleSizeTest;
        private readonly IKolmogorovSmirnovTest _kolmogorovSmirnovTest;
        private readonly IOutliersTest _outliersTest;
        private readonly IBasicStatistics _basicStatistics;
        private readonly ITTest _tTest;
        private readonly IRandomnessTest _randomnessTest;

        public IntervalStrategy(IShapiroWilkTest shapiroWilkTest, ISampleSizeTest sampleSizeTest, 
            IKolmogorovSmirnovTest kolmogorovSmirnovTest, IOutliersTest outliersTest, IBasicStatistics basicStatistics, ITTest tTest,
            IRandomnessTest randomnessTest)
        {
            _shapiroWilkTest = shapiroWilkTest;
            _sampleSizeTest = sampleSizeTest;
            _kolmogorovSmirnovTest = kolmogorovSmirnovTest;
            _outliersTest = outliersTest;
            _basicStatistics = basicStatistics;
            _tTest = tTest;
            _randomnessTest = randomnessTest; 
        }

        public OutputData Execute(InputData inputData)
        {
            var resultValue = _sampleSizeTest.Calculate(inputData.xValues) +
                "<li><b>Test do oceny losowości próby: </b></li>" + _randomnessTest.Calculate(inputData.xValues) +
                "<li><b>Test dla wartości odstających: </b></li>" + _outliersTest.Calculate(inputData.xValues) +              
                "<li><b>Podstawowe statystyki: </b></li>" + _basicStatistics.Calculate(inputData.xValues) +
                "<li><b>Test Shapiro-Wilka: </b></li>" + _shapiroWilkTest.Calculate(inputData.xValues) +
                "<li><b>Test Kolmogorova-Smirnova: </b></li>" + _kolmogorovSmirnovTest.Calculate(inputData.xValues) +
                "<li><b>Test dla wartości oczekiwanej: </b></li>" + _tTest.Calculate(inputData.xValues);

            var resultKey = Translations.SampleSizeTest;

            return OutputData.Success(resultValue, resultKey);
        }
    }
}
