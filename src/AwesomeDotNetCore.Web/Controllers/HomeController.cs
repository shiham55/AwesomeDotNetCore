using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using AwesomeDotNetCore.Models;
using AwesomeDotNetCore.Service.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using System.Diagnostics;

namespace AwesomeDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Store> _storeRepository;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public HomeController(IConfiguration config, 
            IRepository<Product> productRepository,
            IRepository<Store> storeRepository,
            IEmailService emailService)
        {
            _configuration = config;
            _productRepository = productRepository;
            _storeRepository = storeRepository;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            SendGrid.Helpers.Mail.EmailAddress From = new SendGrid.Helpers.Mail.EmailAddress("shiham55@gmail.com", "Shiham M");
            SendGrid.Helpers.Mail.EmailAddress ReplyTo = new SendGrid.Helpers.Mail.EmailAddress("shiham.mohamed@sg.ey.com");
            string Subject = "Testing SendGrid Email Service";
            string HtmlContent = "<p>This is a Test!</p>";
            string PlainTextContent = "This is a Test!";

            var msg  = MailHelper.CreateSingleEmail(From, ReplyTo, Subject, PlainTextContent, HtmlContent);

            _emailService.Send(msg);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Stores()
        {
            return View(_storeRepository.Get());
        }

        public IActionResult Products()
        {
            var allProducts = _productRepository.Get(includeProperties: "BillOfMaterialsComponent");

            var applicationUrl = _configuration["Application:Url"];

            return View(allProducts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
