using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Temp.Converter.Models.DataModels.Common;

namespace Temp.Converter.Logger.Interfaces
{
    public interface ILog
    {
        void LogException(Exception ex, ErrorMsg message, object payLoad, ILogger logger);
    }
}
