using ShopTARgv23.Core.Dto.Games;
using Nancy.Json;
using ShopTARgv23.Core.ServiceInterface;
using System.Net;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class GamesServices : IGamesServices
    {
        public async Task<GamesResultDto> GamesResult(GamesResultDto dto)
        {
            string url = $"http://www.freetogame.com/api/games";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                List<GamesRootDto> gamesRoot = new JavaScriptSerializer()
                    .Deserialize<List<GamesRootDto>>(json);

                if (dto.GameDto == null)
                {
                    dto.GameDto = new List<GameDto>();
                }

                for (var i = 0; i <= gamesRoot.Count(); i++)
                {
                    var root = gamesRoot[i];

                    if (dto.GameDto.Count <= i)
                    {
                        dto.GameDto.Add(new GameDto());
                    }

                    var result = dto.GameDto[i];

                    result.id = root.id;
                    result.title = root.title;
                    result.thumbnail = root.thumbnail;
                    result.short_description = root.short_description;
                    result.game_url = root.game_url;
                    result.genre = root.genre;
                    result.platform = root.platform;
                    result.publisher = root.publisher;
                    result.developer = root.developer;
                    result.release_date = root.release_date;
                    result.freetogame_profile_url = root.freetogame_profile_url;
                }
            }

            return dto;
        }
    }
}
