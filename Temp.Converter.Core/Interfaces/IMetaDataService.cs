using System;
using System.Collections.Generic;
using System.Text;
using Temp.Converter.Models.DataModels.Common;

namespace Temp.Converter.Core.Interfaces
{
    public interface IMetaDataService
    {
        SrvResponse<List<string>> GetTemperatureMetaData();
    }
}
