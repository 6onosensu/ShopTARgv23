using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;

namespace ShopTARgv23.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _services;

        public class
        public IActionResult Index()
        {
            return View();
        }
    }
}
