using HypothesisTestingNew.Domain.Ports.Statistics;

namespace HypothesisTestingNew.Domain
{
    public static class Constants
    {
        public static class SamplesTypes
        {
            public const string Paired = nameof(Paired);
            public const string Independent = nameof(Independent);
        }

        public static class ScaleMeasures
        {
            public const string Nominal = nameof(Nominal);
            public const string Ordinal = nameof(Ordinal);
            public const string Interval = nameof(Interval);
        }

        public static class Translations
        {
            public const string DistributionTest = nameof(DistributionTest);
            public const string DistributionTestMethod = nameof(DistributionTestMethod);
            public const string SnedecorTestMethod = nameof(SnedecorTestMethod);
            public const string SnedecorTest = nameof(SnedecorTest);
            public const string ManWhitneyTestMethod = nameof(ManWhitneyTestMethod);
            public const string StudentIndependentWithEqualVariancesTestMethod = nameof(StudentIndependentWithEqualVariancesTestMethod);
            public const string StudentIndependentWithNotEqualVariancesTestMethod = nameof(StudentIndependentWithNotEqualVariancesTestMethod);
            public const string StudentPairedTestMethod = nameof(StudentPairedTestMethod);
            public const string WilcoxonSignedRankTestMethod = nameof(WilcoxonSignedRankTestMethod);

            public const string StrategyNotFound = nameof(StrategyNotFound);
            public const string SelectingStrategy = nameof(SelectingStrategy);
            public const string ExpectedValueResult = nameof(ExpectedValueResult);
            public const string SamePopulationResult = nameof(SamePopulationResult);
            public const string HistogramResult = nameof(HistogramResult);
            public const string ShapiroWilkTest = nameof(ShapiroWilkTest);
            public const string ModaTest = nameof(ModaTest);
            public const string MedianaTest = nameof(MedianaTest);
            public const string RandomnessTest = nameof(RandomnessTest);
            public const string Conclusion1RandomnessTest = nameof(Conclusion1RandomnessTest);
            public const string Conclusion2RandomnessTest = nameof(Conclusion2RandomnessTest);
            public const string Conclusion3RandomnessTest = nameof(Conclusion3RandomnessTest);
            public const string SampleSizeTest = nameof(SampleSizeTest);
        }

        public const double DefaultSignificance = 0.05;
    }
}
