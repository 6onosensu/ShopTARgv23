using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Data;
using ShopTARgv23.Models.Kindergarten;

namespace ShopTARgv23.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly ShopTARgv23Context _context;
        public KindergartenController (ShopTARgv23Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Kindergarten
                .Select( x => new KindergartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    Teacher = x.Teacher,
                });

            return View(result);
        }
    }
}
