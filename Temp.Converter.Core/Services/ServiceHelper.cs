using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Temp.Converter.Core.Interfaces;
using Temp.Converter.Models.DataModels.Common;

namespace Temp.Converter.Core.Services
{
    public class ServiceHelper: IServiceHelper
    {

        #region Private Members
        private readonly ILogger _logger;
        #endregion

        #region Constructors
        public ServiceHelper(ILogger<ServiceHelper> logger)
        {
            _logger = logger;

        }
        #endregion


        #region Methods
        /// <summary>
        /// Initialize the server response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public SrvResponse<T> InitializeSrvResponse<T>() where T : class
        {
            var     srvResponse         = new SrvResponse<T>()
            {
                IsSuccess               = false,
                Error                   = null,
                CorrelationId           = string.Empty
            };

            return srvResponse;
        }

        /// <summary>
        /// Set the success response with return data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="srvResponse"></param>
        /// <returns></returns>
        public SrvResponse<T> SetSuccessResponse<T>(T data, SrvResponse<T> srvResponse) where T : class
        {
            srvResponse.IsSuccess       = true;
            srvResponse.Data            = data;

            return srvResponse;
        }

        /// <summary>
        /// Set failure response
        /// Handling error logging (Guid Id is used to querying reference)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ex"></param>
        /// <param name="srvResponse"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public SrvResponse<T> SetFailureResponse<T>(Exception ex, SrvResponse<T> srvResponse, object data) where T : class
        {
            srvResponse.IsSuccess       = false;
            srvResponse.Error           = new ErrorMsg()
            {
                Message                 = ex.Message,
                Id                      = Guid.NewGuid().ToString()
            };
            srvResponse.CorrelationId   = Guid.NewGuid().ToString();

            if (data != null)
            {
                _logger.LogError(ex, "ID: {id}, Error Message: {message}, Payload: {payload}", srvResponse.Error.Id, srvResponse.Error.Message, JsonSerializer.Serialize(data));
            }
            else
            {
                _logger.LogError(ex, "ID: {id}, Error Message: {message}", srvResponse.Error.Id, srvResponse.Error.Message);
            }


            return srvResponse;
        }
        #endregion
    }
}
