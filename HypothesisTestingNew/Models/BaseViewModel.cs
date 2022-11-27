using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HypothesisTestingNew.Domain.Ports.Translations;

namespace HypothesisTestingNew.Models
{
    public abstract class BaseViewModel
    {
        public string Language { get; }

        private readonly ITranslator _translator;

        protected BaseViewModel(string language, ITranslator translator)
        {
            Language = language;
            _translator = translator;
        }

        public string GetTranslation(string key) => _translator.Translate(key);
    }
}
