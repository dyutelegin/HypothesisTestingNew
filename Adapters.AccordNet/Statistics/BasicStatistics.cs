using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class BasicStatistics : IBasicStatistics
    {
        public string Calculate(double[] sample)
        {
            var randomnessTest = new RandomnessTest();
            var sampleTest = new SampleSizeTest();
            var modaTest = new ModaTest();
            var medianaTest = new MedianaTest();
            
            Array.Sort(sample);
            int count = sample.Length;
            double sum = randomnessTest.Sum(sample);
            double average = randomnessTest.Average(sample);
            double mediana = medianaTest.Calculate(sample);
            string moda = modaTest.Calculate(sample);
            double largest = sample[count - 1];
            double smallest = sample[0];
            double geometricMean = Math.Pow(Multiplication(sample), (1 / sample.Length));
            double range = largest - smallest;
            double variance = sampleTest.Variance(sample);
            double standardDevision = Math.Sqrt(variance);
            double sampleStandardDeviation = SampleStandardDeviation(sample);

            string htmlTable = "<table table border=\"3\" align=\"left\" style=\"width:40%; table-layout:fixed;\" >" +
                "<tbody>" +
                "<tr>" +
                "<td><b>Statistic</b>" +
                "</td>" +
                "<td><b>Wynik</b>" +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td><b>Ilość</b>" + 
                "</td>" +
                "<td>" + count +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Suma</b>" +
                "</td>" +
                "<td>" + String.Format("{0:N3}", sum) +
                "</td>" + 
                "</tr>" +
                "<td><b>Średnia</b>" +
                "</td>" +
                "<td>" + String.Format("{0:N3}", average) +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Mediana</b>" +
                "</td>" +
                "<td>" + mediana +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Moda</b>" +
                "</td>" +
                "<td>" + moda +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Największy</b>" +
                "</td>" +
                "<td>" + largest +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Najmniejszy</b>" +
                "</td>" +
                "<td>" + smallest +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td><b>Średnia Geometryczna</b>" +
                "</td>" +
                "<td>" + String.Format("{0:N3}", geometricMean) +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Zasięg</b>" +
                "</td>" +
                "<td>" + range +
                "</td>" + 
                "</tr>" +
                "<td><b>Wariancja</b>" +
                "</td>" +
                "<td>" + String.Format("{0:N3}", variance) +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Odchylenie Standardowe</b>" +
                "</td>" +
                "<td>" + String.Format("{0:N3}", standardDevision) +
                "</td>" + 
                "</tr>" +
                "<tr>" +
                "<td><b>Przykładowe Odchylenie Standardowe</b>" +
                "</td>" +
                "<td>" + String.Format("{0:N3}", sampleStandardDeviation) +
                "</td>" + 
                "</tr>" +
                "</tbody>" +
                "</table>";

            return htmlTable;
        }

        public double Multiplication(double[] sample)
        {
            double result = sample.Aggregate((x, y) => x * y);
            return result;
        }

        public double SampleStandardDeviation(double[] sample)
        {
            var sampleTest = new SampleSizeTest();
            double result = 0.0;
            double average = sampleTest.Average(sample);
            for (int i = 0; i < sample.Length; i++)
            {
                result += Math.Pow((sample[i] - average), 2);
            }

            return Math.Sqrt(result/(sample.Length - 1));
        }
    }
}
