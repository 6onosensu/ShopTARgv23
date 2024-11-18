using Microsoft.AspNetCore.Mvc;

namespace ShopTARgv23.Controllers
{
    public class CoctailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
