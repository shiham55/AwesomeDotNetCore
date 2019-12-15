using AwesomeDotNetCore.Data;
using AwesomeDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;

namespace AwesomeDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdventureWorks2017Context _dbContext;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration config, AdventureWorks2017Context dbContext)
        {
            _configuration = config;
            _dbContext = dbContext;
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
            return View(_dbContext.Store.ToList());
        }

        public IActionResult Products()
        {
            return View(_dbContext.Product.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
