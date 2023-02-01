using HypothesisTestingNew.Domain.Ports.Statistics;
using HypothesisTestingNew.Domain.Ports.Translations;
using HypothesisTestingNew.Domain.Services;
using HypothesisTestingNew.Domain.Strategies;
using HypothesisTestingNew.Web.Infrastructure.Translations;
using Microsoft.Extensions.DependencyInjection;

namespace HypothesisTestingNew.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHypothesisTesting(this IServiceCollection services) => services
           .AddInfrastructure()
           .AddStrategies();

        private static IServiceCollection AddInfrastructure(this IServiceCollection services) => services
            .AddScoped<IExecutor, Executor>()
            .AddScoped<IExecutionLogger, ExecutionLogger>()
            .AddScoped<ITranslationsProvider, TranslationsProvider>()
            .AddScoped<ITranslator, Translator>()
            .AddScoped<ILanguageProvider, LanguageProvider>();

        private static IServiceCollection AddStrategies(this IServiceCollection services) => services
            .AddScoped<IStrategy, IntervalStrategy>()
            .AddScoped<IStrategy, NominalSrategy>()
            .AddScoped<IStrategy, OrdinalStrategy>();


    }
}
