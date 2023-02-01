using HypothesisTestingNew.Domain.Ports.Translations;

namespace HypothesisTestingNew.Web.Infrastructure.Translations
{
    public class LanguageProvider : ILanguageProvider
    {
        private static string _language;

        public string Language => _language;

        public void SetLanguage(string language)
        {
            _language = language;
        }
    }
}
