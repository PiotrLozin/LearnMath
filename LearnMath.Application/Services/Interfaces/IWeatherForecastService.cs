﻿using LearnMath.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMath.Application.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        List<WeatherForecast> GetForecasts();
    }
}
