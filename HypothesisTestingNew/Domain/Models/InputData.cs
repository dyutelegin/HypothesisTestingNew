namespace HypothesisTestingNew.Domain.Models
{
    public class InputData
    {
        public DataSeries XValues { get; }

        public string SampleType { get; }

        public string ScaleMeasure { get; }

        public double Significance { get; }

        public InputData(DataSeries xValues, string sampleType, string scaleMeasure, double significance)
        {
            XValues = xValues;
            SampleType = sampleType;
            ScaleMeasure = scaleMeasure;
            Significance = significance;
        }

        public InputData(double[] s1)
        {
            XValues = new DataSeries(s1);
            Significance = Constants.DefaultSignificance;
        }
    }
}
