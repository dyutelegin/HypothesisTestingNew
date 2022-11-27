namespace HypothesisTestingNew.Domain.Ports.Translations
{
    public interface ILanguageProvider
    {
        string Language { get; }

        void SetLanguage(string language);
    }
}
