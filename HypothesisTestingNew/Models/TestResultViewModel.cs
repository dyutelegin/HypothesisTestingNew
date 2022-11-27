using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HypothesisTestingNew.Domain.Ports.Translations;
using HypothesisTestingNew.Domain.Models;
using HypothesisTestingNew.Domain.Services;

namespace HypothesisTestingNew.Models
{
    public class TestResultViewModel: BaseViewModel
    {
        public string XValues { get; set; }

        public IList<string> Logs { get; set; }

        public bool HasError { get; set; }

        public string Error { get; set; }

        public double Significance { get; set; }

        public TestResultViewModel(string language, ITranslator translator)
            : base(language, translator)
        {
        }

        public static TestResultViewModel ToViewModel(string language, ITranslator translator, TestDto testDto, OutputData outputData, IExecutionLogger executionLogger)
        {
            var viewModel = new TestResultViewModel(language, translator)
            {
                Logs = executionLogger.GetLog().ToList(),
                HasError = outputData.HasError,
                Error = outputData.ErrorText,
                XValues = testDto.XValues,
                Significance = testDto.Significance,
            };

            return viewModel;
        }

        public static TestResultViewModel ToErrorViewModel(TestDto dto, ITranslator translator, IExecutionLogger executionLogger, string errorKey = null)
        {
            var viewModel = new TestResultViewModel(dto.Language, translator)
            {
                Logs = executionLogger.GetLog().ToList(),
                HasError = true,
                XValues = dto.XValues,
                Significance = dto.Significance,
                Error = string.IsNullOrWhiteSpace(errorKey) ? string.Empty : translator.Translate(errorKey),
            };

            return viewModel;
        }
    }
}
