using Nancy.Json;
using ShopTARgv23.Core.Dto.WeatherDtos;
using ShopTARgv23.Core.ServiceInterface;
using System.Net;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "ci2IwqXfsFAJYGbeT0Rz1IVO97KQo4sy";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                List<AccuLocationRootDto> accuResult = new JavaScriptSerializer()
                    .Deserialize<List<AccuLocationRootDto>>(json);

                dto.CityName = accuResult[0].Citys[0].LocalizedName;
                dto.CityCode = accuResult[0].Citys[0].Key;
                dto.Rank = accuResult[0].Citys[0].Rank;
            }
            
            return dto;
        }
    }
}
