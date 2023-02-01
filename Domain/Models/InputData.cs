namespace HypothesisTestingNew.Domain.Models
{
    public class InputData
    {
        public double[] xValues { get; }

        public string ScaleMeasures { get; }

        public InputData(double[] s1, string _ScaleMeasures)
        {
            xValues = s1;
            ScaleMeasures = _ScaleMeasures;
        }
    }
}
