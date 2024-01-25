using DressUpAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressUpAI
{
    public class WeatherController
    {
        private WeatherService weatherService;

        public WeatherController()
        {
            weatherService = new WeatherService();
        }

        public async Task<WeatherForecast> GetWeatherInfo(string city)
        {
            return await weatherService.GetWeatherInfo(city);
        }
    }
}
