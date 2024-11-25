using Microsoft.AspNetCore.Mvc;
using ShopTARgv23.Core.ServiceInterface;
using ShopTARgv23.Models.Emails;
using ShopTARgv23.Core.Dto;


namespace ShopTARgv23.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailsServices _services;

        public EmailsController(IEmailsServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(EmailsViewModel model)
        {

            EmailDto dto = new()
            {
                To = model.To,
                Subject = model.Subject,
                Body = model.Body
            };

            _services.SendEmail(dto);
            return RedirectToAction(nameof(Index), model);
        }
    }
}
