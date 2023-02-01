using System.IO;
using HypothesisTestingNew.Domain.Ports.Translations;

namespace HypothesisTestingNew.Web.Infrastructure.Translations
{
    public class TranslationsProvider : ITranslationsProvider
    {
        public string GetTranslations(string lang)
        {
            var translations = File.ReadAllText($"Data/{lang}.json");

            return translations;
        }
    }
}
