using Nancy.Json;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Core.Dto.OpenWeatherMap;
using System.Net;
using System.Runtime.InteropServices;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class OpenWeatherMapServices : IOpenWeatherMap
    {
        public async Task<OpenWeatherMapResultDto> OpenWeatherResult(OpenWeatherMapResultDto dto)
        {
            string apiKey = "588041671253eb42b736a4216772373b";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.city},{dto.country}&appid={apiKey}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OpenWeatherMapRoot weatherRoot = new JavaScriptSerializer().Deserialize<OpenWeatherMapRoot>(json);

                dto.Temperature = weatherRoot.Main.Temp;
                dto.FeelsLike = weatherRoot.Main.FeelsLike;
                dto.WeatherMain = weatherRoot.Weather[0].Main;
                dto.WeatherDescription = weatherRoot.Weather[0].Description;
                dto.WindSpeed = weatherRoot.Wind.Speed;
                dto.Humidity = weatherRoot.Main.Humidity;
                dto.Pressure = weatherRoot.Main.Pressure;

            }

            return dto;
        }
    }
}
