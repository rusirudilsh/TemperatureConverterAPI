using System;
using System.Collections.Generic;
using System.Text;

namespace Temp.Converter.Models.DataModels.Common
{
    public class SrvResponse<T> : ISrvResponse
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
        public ErrorMsg Error { get; set; } = new ErrorMsg();
        public string CorrelationId { get; set; }
    }


    public interface ISrvResponse
    {
        bool IsSuccess { get; set; }
        string Status { get; set; }
        ErrorMsg Error { get; set; }
        string CorrelationId { get; set; }
    }
}
