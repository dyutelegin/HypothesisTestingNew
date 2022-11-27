using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypothesisTestingNew.Domain.Ports.Translations
{
    public interface ITranslator
    {
        string Translate(string key);

        string Translate(string key, params object[] values);
    }
}
