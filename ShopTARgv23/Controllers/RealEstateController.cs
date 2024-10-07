using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Data;
using ShopTARgv23.Models.RealEstate;

namespace ShopTARgv23.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopTARgv23Context _context;
        private readonly IRealEstate _realEstate;
        public RealEstateController(ShopTARgv23Context context, IRealEstate realEstate)
        {
            _context = context;
            _realEstate = realEstate;
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

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel estate = new();

            return View("CreateUpdate", estate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Location = vm.Location,
                Size = vm.Size,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
            };

            var result = await _realEstate.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var estate = await _realEstate.Details(id);
            if (estate == null) { return NotFound(); }
            var vm = new RealEstateDetailsViewModel();

            vm.Id = estate.Id;
            vm.Location = estate.Location;
            vm.Size = estate.Size;
            vm.RoomNumber = estate.RoomNumber;
            vm.BuildingType = estate.BuildingType;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var estate = await _realEstate.Details(id);
            if (estate == null) { return NotFound(); }

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = estate.Id;
            vm.Location = estate.Location;
            vm.Size = estate.Size;
            vm.RoomNumber = estate.RoomNumber;
            vm.BuildingType = estate.BuildingType;
            vm.ModifiedAt = estate.ModifiedAt;
            vm.CreatedAt = estate.CreatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Location = vm.Location,
                Size = vm.Size,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                ModifiedAt = vm.ModifiedAt,
                CreatedAt = vm.CreatedAt
            };

            var result = await _realEstate.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var estate = await _realEstate.Details(id);

            if (estate == null)
            {
                return NotFound();
            }
            var vm = new RealEstateDeleteViewModel();

            vm.Id = estate.Id;
            vm.Location = estate.Location;
            vm.Size = estate.Size;
            vm.RoomNumber = estate.RoomNumber;
            vm.BuildingType = estate.BuildingType;
            vm.CreatedAt = estate.CreatedAt;
            vm.ModifiedAt = estate.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var estate = await _realEstate.Delete(id);

            if (estate == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
