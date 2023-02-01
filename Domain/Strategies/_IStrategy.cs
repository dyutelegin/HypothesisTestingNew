using HypothesisTestingNew.Domain.Models;

namespace HypothesisTestingNew.Domain.Strategies
{
    public interface IStrategy
    {
        string ScaleMeasures { get; }

        OutputData Execute(InputData input); 
    }
}
