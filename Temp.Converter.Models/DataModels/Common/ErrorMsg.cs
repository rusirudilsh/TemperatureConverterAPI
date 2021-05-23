using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Temp.Converter.Models.DataModels.Common
{
    public class ErrorMsg
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("error")]
        public string Message { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
