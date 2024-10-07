using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Data;
using ShopTARgv23.Models.RealEstate;

namespace ShopTARgv23.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopTARgv23Context _context;
        public RealEstateController(ShopTARgv23Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Location = x.Location,
                    Size = x.Size,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });

            return View(result);
        }
    }
}
