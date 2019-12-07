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

        public HomeController(IConfiguration config)
        {
            _configuration = config;
            _dbContext = new AdventureWorks2017Context(_configuration);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
