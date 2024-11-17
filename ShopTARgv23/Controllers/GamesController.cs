using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Core.Dto.Games;
using ShopTARgv23.Models.games;
using ShopTARgv23.ApplicationServices.Services;

namespace ShopTARgv23.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesServices _services;

        public GamesController(IGamesServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            GamesResultDto dto = new();
            await _services.GamesResult(dto);

            var result = dto.GameDto.Select(g => new GamesViewModel
            {
                title = g.title,
                genre = g.genre,
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Game(int id)
        {
            GamesResultDto dto = new();

            await _services.GamesResult(dto);

            var gameDto = dto.GameDto.FirstOrDefault(g => g.id == id);

            GameViewModel vm = new()
            {
                id = gameDto.id,
                title = gameDto.title,
                thumbnail = gameDto.thumbnail,
                short_description = gameDto.short_description,
                game_url = gameDto.game_url,
                genre = gameDto.genre,
                platform = gameDto.platform,
                publisher = gameDto.publisher,
                developer = gameDto.developer,
                release_date = gameDto.release_date,
                freetogame_profile_url = gameDto.freetogame_profile_url
            };

            return View(vm);
        }
    }
}
