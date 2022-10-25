using Microsoft.AspNetCore.Mvc;
using MySQLBackend.Models;
using System.Diagnostics;

namespace MySQLBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DatabaseHelper.DatabaseHelper.InsertUser(new Models.User()
            {
                Name = "Jennifer",
                LastName = "Johnson",
                Address = "New York",
                Email = "jen.johnson@gmail.com",
                Phone = 64646464,
                DateIn = DateTime.Now
            });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}