using Accord.Statistics.Testing;
using HypothesisTestingNew.Adapters.AccordNet.Statistics;
using HypothesisTestingNew.Domain.Ports.Statistics;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTestingNew.Adapters.AccordNET.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccordNet(this IServiceCollection services) => services
            .AddScoped<IShapiroWilkTest, ShapiroWilkTestImplementation>()
            .AddScoped<IHistogramTest, HistogramTest>()
            .AddScoped<IModaTest, ModaTest>()
            .AddScoped<IMedianaTest, MedianaTest>()
            .AddScoped<IRandomnessTest, RandomnessTest>()
            .AddScoped<ISampleSizeTest, SampleSizeTest>()
            .AddScoped<IKolmogorovSmirnovTest, KolmogorovSmirnovTestImplementation>()
            .AddScoped<IOutliersTest, OutliersTest>()
            .AddScoped<IBasicStatistics, BasicStatistics>()
            .AddScoped<ITTest, TTestImplementation>()
            .AddScoped<IBinomialTest, BinomialTestImplementation>()
            .AddScoped<IProportionTest, ProportionTest>()
            .AddScoped<INormalTest, NormalTest>();
    }
}
