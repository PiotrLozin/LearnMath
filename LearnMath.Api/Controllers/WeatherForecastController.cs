using LearnMath.Application.Services.Interfaces;
using LearnMath.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LearnMath.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(List<WeatherForecast>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get()
        {
            var result = _weatherForecastService.GetForecasts();
            if(!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}