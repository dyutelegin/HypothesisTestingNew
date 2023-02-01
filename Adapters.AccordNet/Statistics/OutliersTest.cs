using HypothesisTestingNew.Domain.Ports.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypothesisTestingNew.Adapters.AccordNet.Statistics
{
    public class OutliersTest : IOutliersTest
    {
        public string Calculate(double[] sample)
        {
            Array.Sort(sample);

            int iSize = sample.Length;
            int iMid = iSize / 2; //this is the mid from a zero based index, eg mid of 7 = 3;

            double fQ1 = 0.0; //First
            double fQ2 = 0.0; //Second Meniana
            double fQ3 = 0.0; //Thrid

            if (iSize % 2 == 0)
            {
                //================ EVEN NUMBER OF POINTS: =====================
                //even between low and high point
                fQ2 = (sample[iMid - 1] + sample[iMid]) / 2;

                int iMidMid = iMid / 2;

                //easy split 
                if (iMid % 2 == 0)
                {
                    fQ1 = (sample[iMidMid - 1] + sample[iMidMid]) / 2;
                    fQ3 = (sample[iMid + iMidMid - 1] + sample[iMid + iMidMid]) / 2;
                }
                else
                {
                    fQ1 = sample[iMidMid];
                    fQ3 = sample[iMidMid + iMid];
                }
            }
            else if (iSize == 1)
            {
                //================= special case ================
                fQ1 = sample[0];
                fQ2 = sample[0];
                fQ3 = sample[0];
            }
            else
            {
                //odd number so the median is just the midpoint in the array.
                fQ2 = sample[iMid];

                if ((iSize - 1) % 4 == 0)
                {
                    //======================(4n-1) POINTS =========================
                    int n = (iSize - 1) / 4;
                    fQ1 = (sample[n - 1] * .25) + (sample[n] * .75);
                    fQ3 = (sample[3 * n] * .75) + (sample[3 * n + 1] * .25);
                }
                else if ((iSize - 3) % 4 == 0)
                {
                    //======================(4n-3) POINTS =========================
                    int n = (iSize - 3) / 4;

                    fQ1 = (sample[n] * .75) + (sample[n + 1] * .25);
                    fQ3 = (sample[3 * n + 1] * .25) + (sample[3 * n + 2] * .75);
                }
            }

            List<double> outliersArr = new List<double>();

            double IQR = Math.Abs(fQ1) + Math.Abs(fQ3);
            double outlierDown = -(IQR * 1.5 + Math.Abs(fQ1));
            double outlierUp = IQR * 1.5 + fQ3;           

            foreach (double sampleVal in sample)
            {
                if(sampleVal <= outlierDown || sampleVal >= outlierUp)
                {
                    outliersArr.Add(sampleVal);
                }
            }

            string result = "<br><b>Posortowana lista: </b>" + String.Join(" ", sample) +
                "<br><b>Q1: </b>" + String.Format("{0:N3}", fQ1) +
                "<br><b>Q2: </b>" + String.Format("{0:N3}", fQ2) + " (Mediana) " +
                "<br><b>Q3: </b>" + String.Format("{0:N3}", fQ3) +
                "<br><b>IQR: </b>" + String.Format("{0:N3}", IQR) +
                "<br>Wartości odstające to punkty mniejsze niż: " + "<b>" + String.Format("{0:N3}", outlierDown) +"</b>" 
                + " lub większa niż: " + "<b>" + String.Format("{0:N3}", outlierUp) + "</b>";

            if (outliersArr.Count == 0)
            {
                return "Wartości odstające to: <b>brak</b>" + result;
            } else
            {
                return "<b>Wartości odstające to: </b>" + String.Join(" ", outliersArr) + result;
            }
        }
    }
}
