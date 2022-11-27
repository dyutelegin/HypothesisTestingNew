using HypothesisTestingNew.Domain.Models;

namespace HypothesisTestingNew.Domain.Strategies
{
    public interface IStrategy
    {
        string SampleType { get; }

        string ScaleMeasure { get; }

        OutputData Execute(InputData input);
    }
}
