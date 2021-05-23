using System;
using System.Collections.Generic;
using System.Text;
using Temp.Converter.Core.Interfaces;
using Temp.Converter.Models.DataModels.Common;
using static Temp.Converter.Models.Constants.Constants;

namespace Temp.Converter.Core.Services
{
    public class MetaDataService : IMetaDataService
    {


        #region PrivateProperties

        private readonly IServiceHelper _serviceHelper;

        #endregion

        #region Constructor
        public MetaDataService(IServiceHelper serviceHelper)
        {
            _serviceHelper = serviceHelper;

        }
        #endregion


        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SrvResponse<List<string>> GetTemperatureMetaData()
        {
            var         srvResponse      = _serviceHelper.InitializeSrvResponse<List<string>>();

            try
            {
                var     result           = new List<string>();
                result.Add(TemperatureTypes.Celsius);
                result.Add(TemperatureTypes.Fahrenheit);
                result.Add(TemperatureTypes.Kelvin);
                srvResponse              = _serviceHelper.SetSuccessResponse(result, srvResponse);
            }
            catch (Exception ex)
            {
                srvResponse              = _serviceHelper.SetFailureResponse(ex, srvResponse, null);
            }

            return srvResponse;
        }
        #endregion
    }
}
