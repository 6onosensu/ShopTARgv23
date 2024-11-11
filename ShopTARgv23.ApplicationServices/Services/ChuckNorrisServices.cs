using ShopTARgv23.Core.Dto.ChuckNorris;
using ShopTARgv23.Core.ServiceInterface;
using System.Net;
using Nancy.Json;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {
        public async Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto)
        {
            var url = "https://api.chucknorris.io/jokes/categories";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                List<ChuckNorrisRootDto> result = new JavaScriptSerializer()
                    .Deserialize<List<ChuckNorrisRootDto>>(json);

                dto.IconUrl = result[0].IconUrl;
                dto.Id = result[0].Id ;
                dto.Url = result[0].Url ;
                dto.Value = result[0].Value;
            }

            return dto;
        }
    }
}
