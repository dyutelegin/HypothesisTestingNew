using System.Collections.Generic;
using System.Linq;
using HypothesisTestingNew.Domain.Extensions;
using HypothesisTestingNew.Domain.Models;
using HypothesisTestingNew.Domain.Ports.Statistics;
using HypothesisTestingNew.Domain.Ports.Translations;
using HypothesisTestingNew.Domain.Strategies;

namespace HypothesisTestingNew.Domain.Services
{
    public interface IExecutor
    {
        //OutputData Execute(InputData inputData);

        OutputData Execute(InputData inputData);
    }

    public class Executor : IExecutor
    {
        private readonly IEnumerable<IStrategy> _strategies;
        private readonly IExecutionLogger _logger;
        private readonly ITranslator _translator;
        private readonly IHistogramTest _histogramTest;

        public Executor(IEnumerable<IStrategy> strategies, IExecutionLogger logger, 
            ITranslator translator, IHistogramTest histogramTest)
        {
            _strategies = strategies;
            _logger = logger;
            _translator = translator;
            _histogramTest = histogramTest;
        }

        // Główny executor
        public OutputData Execute(InputData inputData)
        {
            
            LogStrategy(inputData);

            var strategy = _strategies.SingleOrDefault(x => x.ScaleMeasures == inputData.ScaleMeasures);

            if (strategy == null)
            {
                var notFoundLog = _translator.Translate(Constants.Translations.StrategyNotFound);
                _logger.AddLog(notFoundLog);
                return OutputData.Error();
            }       

            var outputData = strategy.Execute(inputData);

            outputData.Histogram = _histogramTest.Calculate(inputData.xValues);

            LogResult(inputData, outputData);

            return outputData;
        }

        private void LogStrategy(InputData inputData)
        {
            var scaleMeasure = _translator.Translate(inputData.ScaleMeasures);
            var log = _translator.Translate(Constants.Translations.SelectingStrategy, scaleMeasure);          
            _logger.AddLog(log);
        }

        private void LogResult(InputData inputData, OutputData outputData)
        {
            if (outputData.HasError)
            {
                return;
            }
            var histogramResult = _translator.Translate(Constants.Translations.HistogramResult, outputData.Histogram);
            _logger.AddLog(histogramResult);

             if (!string.IsNullOrWhiteSpace(outputData.ResultKey))
             {
                var stringlog = _translator.Translate(outputData.ResultKey, outputData.Moda);
                _logger.AddLog(stringlog);
            }
        }
    }
}
