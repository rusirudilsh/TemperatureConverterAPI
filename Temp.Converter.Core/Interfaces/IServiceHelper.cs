using System;
using System.Collections.Generic;
using System.Text;
using Temp.Converter.Models.DataModels.Common;

namespace Temp.Converter.Core.Interfaces
{
    public interface IServiceHelper
    {
        SrvResponse<T> InitializeSrvResponse<T>() where T : class;
        SrvResponse<T> SetSuccessResponse<T>(T data, SrvResponse<T> srvResponse) where T : class;
        SrvResponse<T> SetFailureResponse<T>(Exception ex, SrvResponse<T> srvResponse, object data) where T : class;
    }
}
