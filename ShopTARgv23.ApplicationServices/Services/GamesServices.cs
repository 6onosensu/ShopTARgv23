using Nancy.Json;
using Nancy;
using ShopTARgv23.Core.Dto.Games;
using Nancy.Json;
using ShopTARgv23.Core.ServiceInterface;
using System.Net;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class GamesServices
    {
        public async Task<GamesResultDto> GamesResult(GamesResultDto dto)
        {
            string url = $"http://www.freetogame.com/api/games";

            using (WebClient client = new WebClient())
            {


            }

            return dto;
        }
    }
}
