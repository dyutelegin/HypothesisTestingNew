using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypothesisTestingNew.Domain.Ports.Translations
{
    public interface ITranslationsProvider
    {
        string GetTranslations(string lang);
    }
}
