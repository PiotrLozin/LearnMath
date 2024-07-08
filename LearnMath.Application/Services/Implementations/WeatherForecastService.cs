using LearnMath.Application.Services.Interfaces;
using LearnMath.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LearnMath.Application.Services.Implementations
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public List<WeatherForecast> GetForecasts()
        {
            var weatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
            return weatherForecast;
        }
    }
}