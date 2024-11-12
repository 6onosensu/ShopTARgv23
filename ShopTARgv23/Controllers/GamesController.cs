using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Core.Dto.Games;
using ShopTARgv23.Models.games;

namespace ShopTARgv23.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesServices _services;

        public GamesController(IGamesServices services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async IActionResult GameDetails(int id)
        {
            var game = new GameViewModel { }
        }
    }
}
