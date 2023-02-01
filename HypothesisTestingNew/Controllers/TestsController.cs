using Microsoft.AspNetCore.Mvc;
using HypothesisTestingNew.Domain.Services;
using HypothesisTestingNew.Domain.Ports.Translations;
using Microsoft.Extensions.Configuration;
using static HypothesisTestingNew.WebConstants;
using HypothesisTestingNew.Domain.Models;
using HypothesisTestingNew.Models;
using HypothesisTestingNew.Infrastructure.Input;

namespace HypothesisTestingNew.Controllers
{
    public class TestsController: Controller
    {
        private readonly IExecutor _executor;
        private readonly IExecutionLogger _executionLogger;
        private readonly ITranslator _translator;
        private readonly ILanguageProvider _languageProvider;
        private readonly IConfiguration _configuration;

        public TestsController(IExecutor executor, IExecutionLogger executionLogger, ITranslator translator, ILanguageProvider languageProvider, IConfiguration configuration)
        {
            _executor = executor;
            _executionLogger = executionLogger;
            _translator = translator;
            _languageProvider = languageProvider;
            _configuration = configuration;
        }

        public IActionResult Index(string language)
        {
            language ??= Languages.Polish;
            _languageProvider.SetLanguage(language);

            var viewModel = new TestViewModel(language, _translator, _configuration);

            return View(viewModel);
        }

        [HttpPost]

        public IActionResult Submit(TestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.XValues))
            {
                return PartialView("Results", TestResultViewModel.ToErrorViewModel(dto, _translator, _executionLogger, Translations.ErrorIncorrectData));
            }

            if (!InputParser.TryParse(dto.XValues, out var x))
            {
                return PartialView("Results", TestResultViewModel.ToErrorViewModel(dto, _translator, _executionLogger, Translations.ErrorIncorrectDataSize));
            }

            if (!InputValidator.IsValid(dto.ScaleMeasure, x))
            {
                return PartialView("Results", TestResultViewModel.ToErrorViewModel(dto, _translator, _executionLogger, Translations.ErrorPairedDataMustHaveSameSize));
            }

            var inputData = new InputData(x, dto.ScaleMeasure);
            var outputData = _executor.Execute(inputData);
            var viewModel = TestResultViewModel.ToViewModel(dto.Language, _translator, dto, outputData, _executionLogger);

            return PartialView("Results", viewModel);
        }
    }
}




