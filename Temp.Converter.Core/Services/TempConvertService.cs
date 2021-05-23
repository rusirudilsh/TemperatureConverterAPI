using System;
using System.Collections.Generic;
using System.Text;
using Temp.Converter.Core.Interfaces;
using Temp.Converter.Core.Utility;
using Temp.Converter.Models.DataModels;
using Temp.Converter.Models.DataModels.Common;

namespace Temp.Converter.Core.Services
{
    public class TempConvertService : ITempConvertService
    {

        #region PrivateProperties

        private readonly IServiceHelper _serviceHelper;

        #endregion

        #region Constructor
        public TempConvertService(IServiceHelper serviceHelper)
        {
            _serviceHelper = serviceHelper;
            
        }
        #endregion


        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public SrvResponse<TempConversionDataModel> ConvertTemperature(InputTempDataModel inputData)
        {
            var         srvResponse      = _serviceHelper.InitializeSrvResponse<TempConversionDataModel>();

            try
            {
                var     result           = TemperatureConverter.ConvertToOtherTypes(inputData);
                srvResponse              = _serviceHelper.SetSuccessResponse(result, srvResponse);
            }
            catch (Exception ex)
            {
                srvResponse              = _serviceHelper.SetFailureResponse(ex, srvResponse, inputData);
            }

            return srvResponse;


        }
        #endregion
    }
}
