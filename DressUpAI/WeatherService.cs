using DressUpAI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DressUpAI
{
    public class WeatherService
    {
        private static readonly string apiKey = "apikey 2KCCX78zHqBkkNFoFH677Q:6c6jE1XBXTQOncvV53ILST";
        private static readonly string apiUrl = "https://api.collectapi.com/weather/getWeather";


        public async Task<WeatherForecast> GetWeatherInfo(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                //Api key'i header'a ekle
                client.DefaultRequestHeaders.Add("authorization", $"apiKey {apiKey}");
                //Apiye get isteği gönder
                var response = await client.GetAsync($"{apiUrl}?data.lang=tr&data.city={city}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    WeatherForecast weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(jsonResponse);

                    return weatherForecast;
                }
                return null;
            }
        }

    }
}
