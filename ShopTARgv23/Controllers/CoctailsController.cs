﻿using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Models.Coctails;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Core.Dto.CocktailDto;

namespace ShopTARgv23.Controllers
{
    public class CoctailsController : Controller
    {
        private readonly ICoctailServices _drinkService;
        public CoctailsController (ICoctailServices drinkService)
        {
            _drinkService = drinkService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCocktails(CoctailSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Coctail", "Coctails", new { coctail = model.SearchCocktail });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Coctail(string coctail)
        {
            CoctailResultDto dto = new();
            dto.StrDrink = coctail;

            _drinkService.GetDrink(dto);
            CoctailViewModel vm = new();

            vm.IdDrink = dto.IdDrink;
            vm.StrDrink = dto.StrDrink;
            vm.StrDrinkAlternate = dto.StrDrinkAlternate;
            vm.StrTags = dto.StrTags;
            vm.StrVideo = dto.StrVideo;
            vm.StrCategory = dto.StrCategory;
            vm.StrIBA = dto.StrIBA;
            vm.StrAlcoholic = dto.StrAlcoholic;
            vm.StrGlass = dto.StrGlass;
            vm.StrInstructions = dto.StrInstructions;
            vm.StrInstructionsES = dto.StrInstructionsES;
            vm.StrInstructionsDE = dto.StrInstructionsDE;
            vm.StrInstructionsFR = dto.StrInstructionsFR;
            vm.StrInstructionsIT = dto.StrInstructionsIT;
            vm.StrInstructionsZHHANS = dto.StrInstructionsZHHANS;
            vm.StrInstructionsZHHANT = dto.StrInstructionsZHHANT;
            vm.StrDrinkThumb = dto.StrDrinkThumb;
            vm.StrIngredient1 = dto.StrIngredient1;
            vm.StrIngredient2 = dto.StrIngredient2;
            vm.StrIngredient3 = dto.StrIngredient3;
            vm.StrIngredient4 = dto.StrIngredient4;
            vm.StrIngredient5 = dto.StrIngredient5;
            vm.StrIngredient6 = dto.StrIngredient6;
            vm.StrIngredient7 = dto.StrIngredient7;
            vm.StrIngredient8 = dto.StrIngredient8;
            vm.StrIngredient9 = dto.StrIngredient9;
            vm.StrIngredient10 = dto.StrIngredient10;
            vm.StrIngredient11 = dto.StrIngredient11;
            vm.StrIngredient12 = dto.StrIngredient12;
            vm.StrIngredient13 = dto.StrIngredient13;
            vm.StrIngredient14 = dto.StrIngredient14;
            vm.StrIngredient15 = dto.StrIngredient15;
            vm.StrMeasure1 = dto.StrMeasure1;
            vm.StrMeasure2 = dto.StrMeasure2;
            vm.StrMeasure3 = dto.StrMeasure3;
            vm.StrMeasure4 = dto.StrMeasure4;
            vm.StrMeasure5 = dto.StrMeasure5;
            vm.StrMeasure6 = dto.StrMeasure6;
            vm.StrMeasure7 = dto.StrMeasure7;
            vm.StrMeasure8 = dto.StrMeasure8;
            vm.StrMeasure9 = dto.StrMeasure9;
            vm.StrMeasure10 = dto.StrMeasure10;
            vm.StrMeasure11 = dto.StrMeasure11;
            vm.StrMeasure12 = dto.StrMeasure12;
            vm.StrMeasure13 = dto.StrMeasure13;
            vm.StrMeasure14 = dto.StrMeasure14;
            vm.StrMeasure15 = dto.StrMeasure15;
            vm.StrImageSource = dto.StrImageSource;
            vm.StrImageAttribution = dto.StrImageAttribution;
            vm.StrCreativeCommonsConfirmed = dto.StrCreativeCommonsConfirmed;
            vm.DateModified = dto.DateModified;

            return View(vm);
        }
    }
}
