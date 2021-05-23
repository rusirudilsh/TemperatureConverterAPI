using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temp.Converter.Core.Interfaces;
using Temp.Converter.Core.Services;
using Temp.Converter.Models.DataModels;

namespace Temp.Converter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureConvertController : ControllerBase
    {

        private readonly IMetaDataService _metaDataService; 
        private readonly ITempConvertService _tempConvertService;

        public TemperatureConvertController(IMetaDataService metaDataService, ITempConvertService tempConvertService)
        {
            _metaDataService    = metaDataService;
            _tempConvertService = tempConvertService;
        }
        [HttpGet("GetMetaData")]
        public IActionResult GetMetaData()
        {
            var response = _metaDataService.GetTemperatureMetaData();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }


        [HttpPost("ConvertTemperatureData")]
        public IActionResult ConvertTempData(InputTempDataModel inputData)
        {
            var response =  _tempConvertService.ConvertTemperature(inputData);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response);
        }
    }
}
