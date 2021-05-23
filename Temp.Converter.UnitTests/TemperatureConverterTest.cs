using NUnit.Framework;
using System.Collections.Generic;
using Temp.Converter.Core.Utility;
using Temp.Converter.Models.DataModels;
using static Temp.Converter.Models.Constants.Constants;

namespace Temp.Converter.UnitTests
{
    [TestFixture]
    public class TemperatureConverterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertToOtherTypes_Celsius_ReturnsConvertedData()
        {
            //Arrange
            string[] data = { TemperatureTypes.Fahrenheit, TemperatureTypes.Kelvin };
            TempConversionDataModel expectedResult = new TempConversionDataModel();
            expectedResult.ConvertedData = new List<ConvertedTempData>();
            expectedResult.ConvertedData.Add(new ConvertedTempData {TemperatureType = TemperatureTypes.Fahrenheit , Value = 81.5 });
            expectedResult.ConvertedData.Add(new ConvertedTempData { TemperatureType = TemperatureTypes.Kelvin, Value = 300.65 });

            //Act
            var result = TemperatureConverter.ConvertToOtherTypes(new InputTempDataModel { TemperatureType = TemperatureTypes.Celsius, TemperatureTypesToConvert = data, TemperatureValue = 27.5 });

            //Assert
            Assert.AreEqual(expectedResult.ConvertedData[0].Value, result.ConvertedData[0].Value);
        }

        [Test]
        public void ConvertToOtherTypes_Fahrenheit_ReturnsConvertedData()
        {
            //Arrange
            string[] data = { TemperatureTypes.Celsius, TemperatureTypes.Kelvin };
            TempConversionDataModel expectedResult = new TempConversionDataModel();
            expectedResult.ConvertedData = new List<ConvertedTempData>();
            expectedResult.ConvertedData.Add(new ConvertedTempData { TemperatureType = TemperatureTypes.Celsius, Value = 0 });
            expectedResult.ConvertedData.Add(new ConvertedTempData { TemperatureType = TemperatureTypes.Kelvin, Value = 273.15 });


            //Act
            var result = TemperatureConverter.ConvertToOtherTypes(new InputTempDataModel { TemperatureType = TemperatureTypes.Fahrenheit, TemperatureTypesToConvert = data, TemperatureValue = 32 });

            //Assert
            Assert.AreEqual(expectedResult.ConvertedData[0].Value, result.ConvertedData[0].Value);
        }


        [Test]
        public void ConvertToOtherTypes_Kelvin_ReturnsConvertedData()
        {
            //Arrange
            string[] data = { TemperatureTypes.Fahrenheit, TemperatureTypes.Celsius };
            TempConversionDataModel expectedResult = new TempConversionDataModel();
            expectedResult.ConvertedData = new List<ConvertedTempData>();
            expectedResult.ConvertedData.Add(new ConvertedTempData { TemperatureType = TemperatureTypes.Fahrenheit, Value = -441.67 });
            expectedResult.ConvertedData.Add(new ConvertedTempData { TemperatureType = TemperatureTypes.Celsius, Value = -263.15 });

            //Act
            var result = TemperatureConverter.ConvertToOtherTypes(new InputTempDataModel { TemperatureType = TemperatureTypes.Kelvin, TemperatureTypesToConvert = data, TemperatureValue = 10 });

            //Assert
            Assert.AreEqual(expectedResult.ConvertedData[0].Value, result.ConvertedData[0].Value);
        }
    }
}