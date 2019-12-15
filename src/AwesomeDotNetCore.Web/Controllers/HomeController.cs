using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using AwesomeDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace AwesomeDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration config, IRepository<Product> productRepository)
        {
            _configuration = config;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Page()
        {
            return View();
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
