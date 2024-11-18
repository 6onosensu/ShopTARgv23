using ShopTARgv23.Core.Dto.Coctails;
using ShopTARgv23.Core.ServiceInterface;
using System.Net;
using System.Text.Json;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class CoctailsServces : ICoctailsServices
    {
        public async Task<CoctailsResultDto> GetDrink(CoctailsResultDto dto)
        {
            var url = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                var root = JsonSerializer
                    .Deserialize<CoctailsRootDto>(json);
            }
            return dto;
        }
    }
}
