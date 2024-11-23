using Microsoft.AspNetCore.Mvc;

namespace ShopTARgv23.Controllers
{
    public class OpenWeatherMapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("GetWeather", "OpenWeatherResult")
            }
        }

        [HttpGet] 
        public IActionResult GetWeather()
        {

        }
    }
}
