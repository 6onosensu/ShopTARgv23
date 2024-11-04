using Nancy.Json;
using ShopTARgv23.Core.Dto.WeatherDtos;
using System.Net;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "ci2IwqXfsFAJYGbeT0Rz1IVO97KQo4sy";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                AccuLocationRootDto accuResult = new JavaScriptSerializer().Deserialize<AccuLocationRootDto>(json);
            }
            
            return dto;
        }
    }
}
