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
            var files = Request.Form.Files.Any() ? Request.Form.Files.ToList() : new List<IFormFile>();
            //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            EmailDto dto = new()
            {
                To = model.To,
                Subject = model.Subject,
                Body = model.Body,
                Attachment = files
            };

            _services.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
