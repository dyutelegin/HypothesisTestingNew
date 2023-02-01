using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypothesisTestingNew.Domain.Extensions
{
    public static class DoubleExtensions
    {
        public static string Round(this double d) => $"{d:F3}";
    }
}
