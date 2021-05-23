using System;
using System.Collections.Generic;
using System.Text;
using Temp.Converter.Models.DataModels;
using Temp.Converter.Models.DataModels.Common;

namespace Temp.Converter.Core.Interfaces
{
    public interface ITempConvertService
    {
        SrvResponse<TempConversionDataModel> ConvertTemperature(InputTempDataModel inputData);
    }
}
