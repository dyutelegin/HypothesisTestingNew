using System;
using System.Collections.Generic;
using HypothesisTestingNew.Domain;
using HypothesisTestingNew.Domain.Ports.Translations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace HypothesisTestingNew.Models
{
    public class TestViewModel: BaseViewModel
    {
        public string XValues { get; set; }

        public string SamplesType { get; set; }

        public string ScaleMeasure { get; set; }

        public IEnumerable<SelectListItem> Languages { get; set; }

        public string FlowChartUrl { get; set; }

        public double Significance { get; set; }

        public TestViewModel(string language, ITranslator translator, IConfiguration configuration)
            : base(language, translator)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem("Polski", WebConstants.Languages.Polish),
                new SelectListItem("English", WebConstants.Languages.English),
            };

            SamplesType = Constants.SamplesTypes.Independent;
            ScaleMeasure = Constants.ScaleMeasures.Interval;
            Languages = items;
            FlowChartUrl = configuration.GetValue<string>(WebConstants.AppSettingsKeys.FlowChartUrl);
            Significance = Constants.DefaultSignificance;
            XValues = "0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17";
        }
    }
}
