using System;
using System.Collections.Generic;
using System.Text;

namespace Temp.Converter.Models.DataModels
{
    public class InputTempDataModel
    {
        public string TemperatureType { get; set; }
        public double TemperatureValue { get; set; }
        public string[] TemperatureTypesToConvert { get; set; }
    }
}
