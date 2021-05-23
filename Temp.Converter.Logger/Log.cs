using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Temp.Converter.Logger.Interfaces;
using Temp.Converter.Models.DataModels.Common;

namespace Temp.Converter.Logger
{
    public sealed class Log : ILog
    {

        #region Private Members

        private static readonly Lazy<Log> logInstance = new Lazy<Log>(() => new Log());
        #endregion


        #region Constructors
        private Log()
        {

        }
        #endregion

        #region Properties
        public static Log GetLogInstance
        {
            get
            {
                return logInstance.Value;
            }
        }
        #endregion


        #region Methods

        /// <summary>
        /// log error messeage and payload data along with Guid id in azure app insights
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="payLoad"></param>
        /// <param name="logger"></param>
        public void LogException(Exception ex, ErrorMsg message, object payLoad, ILogger logger)
        {
            if (payLoad != null)
            {
                logger.LogError(ex, "ID: {id}, Error Message: {message}, Payload: {payload}", message.Id, message.Message, JsonSerializer.Serialize(payLoad));
            }
            else
            {
                logger.LogError(ex, "ID: {id}, Error Message: {message}", message.Id, message.Message);
            }
        }
        #endregion
    }
}
