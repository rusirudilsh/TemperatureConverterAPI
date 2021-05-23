using System;
using System.Collections.Generic;
using System.Text;
using Temp.Converter.Models.DataModels;
using static Temp.Converter.Models.Constants.Constants;

namespace Temp.Converter.Core.Utility
{
    public static class TemperatureConverter
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static TempConversionDataModel ConvertToOtherTypes(InputTempDataModel inputData)
        {
            List<ConvertedTempData>     result          = new List<ConvertedTempData>();
            TempConversionDataModel     resultModel     = null;
            try
            {
               
                if (inputData != null && inputData.TemperatureTypesToConvert != null && inputData.TemperatureTypesToConvert.Length > 0)
                {

                    switch (inputData.TemperatureType)
                    {
                        //if user inputs Celsius value to convert in to other types
                        case TemperatureTypes.Celsius:
                            foreach (var item in inputData.TemperatureTypesToConvert)
                            {
                                if (item == TemperatureTypes.Fahrenheit)
                                {
                                    result.Add(CelsiusToFahrenheit(inputData.TemperatureValue));
                                }
                                if (item == TemperatureTypes.Kelvin)
                                {
                                    result.Add(CelsiusToKelvin(inputData.TemperatureValue));
                                }

                            }
                            break;

                        //if user inputs Fahrenheit value to convert in to other types
                        case TemperatureTypes.Fahrenheit:
                            foreach (var item in inputData.TemperatureTypesToConvert)
                            {
                                if (item == TemperatureTypes.Celsius)
                                {
                                    result.Add(FahrenheitToCelsius(inputData.TemperatureValue));
                                }
                                if (item == TemperatureTypes.Kelvin)
                                {
                                    result.Add(FahrenheitToKelvin(inputData.TemperatureValue));
                                }

                            }
                            break;

                        //if user inputs Kelvin value to convert in to other types
                        case TemperatureTypes.Kelvin:
                            foreach (var item in inputData.TemperatureTypesToConvert)
                            {
                                if (item == TemperatureTypes.Fahrenheit)
                                {
                                    result.Add(KelvinToFahrenheit(inputData.TemperatureValue));
                                }
                                if (item == TemperatureTypes.Celsius)
                                {
                                    result.Add(KelvinToCelsius(inputData.TemperatureValue));
                                }

                            }
                            break;
                    }

                  
                }
                resultModel                         = new TempConversionDataModel();
                resultModel.ConvertedData           = result;
               

            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }

            return resultModel;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fahrenheit"></param>
        /// <returns></returns>
        private static ConvertedTempData FahrenheitToCelsius(double fahrenheit)
        {
            return new ConvertedTempData { Value = Math.Round((fahrenheit - 32) * 5 / 9, 2), TemperatureType = TemperatureTypes.Celsius };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fahrenheit"></param>
        /// <returns></returns>
        private static ConvertedTempData FahrenheitToKelvin(double fahrenheit)
        {
            return new ConvertedTempData { Value = Math.Round((fahrenheit - 32) * 5 / 9 + 273.15, 2 ), TemperatureType = TemperatureTypes.Kelvin };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="celsius"></param>
        /// <returns></returns>
        private static ConvertedTempData CelsiusToFahrenheit(double celsius)
        {
            return new ConvertedTempData { Value = Math.Round((celsius * 9 / 5) + 32, 2), TemperatureType = TemperatureTypes.Fahrenheit };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="celsius"></param>
        /// <returns></returns>
        private static ConvertedTempData CelsiusToKelvin(double celsius)
        {
            return new ConvertedTempData { Value = Math.Round((celsius + 273.15),2), TemperatureType = TemperatureTypes.Kelvin };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kelvin"></param>
        /// <returns></returns>
        private static ConvertedTempData KelvinToFahrenheit(double kelvin)
        {
            return new ConvertedTempData { Value = Math.Round((kelvin - 273.15) * 9 / 5 + 32, 2), TemperatureType = TemperatureTypes.Fahrenheit };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="kelvin"></param>
        /// <returns></returns>
        private static ConvertedTempData KelvinToCelsius(double kelvin)
        {
            return new ConvertedTempData { Value = Math.Round((kelvin - 273.15), 2), TemperatureType = TemperatureTypes.Celsius };
        }

        #endregion
    }
}
