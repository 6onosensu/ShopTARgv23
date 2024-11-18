using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.Dto.Coctails;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.Coctails;

namespace ShopTARgv23.Controllers
{
    public class CoctailsController : Controller
    {
        private readonly ICoctailsServices _drinkService;
        public CoctailsController (ICoctailsServices drinkService)
        {
            _drinkService = drinkService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchDrink(DrinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Drink", "", new { drink = model.strDrink });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Drink(string coctail)
        {
            CoctailsResultDto dto = new();
            dto.strDrink = coctail();

            _drinkService.GetDrink(dto);
            DrinkViewModel vm = new();
            return View(vm);
        }
    }
}
