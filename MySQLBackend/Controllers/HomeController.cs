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
            ViewBag.UserList = DatabaseHelper.DatabaseHelper.GetUsers();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.User = DatabaseHelper.DatabaseHelper.GetUser(id);

            return View();
        }

        public IActionResult DeleteUser(int id)
        {
            DatabaseHelper.DatabaseHelper.DeleteUser(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveUser(string txtName,
                                    string txtLastName,
                                    string txtPhone,
                                    string txtEmail,
                                    string txtAddress)
        {
            DatabaseHelper.DatabaseHelper.InsertUser(new Models.User()
            {
                Name = txtName,
                LastName = txtLastName,
                Address = txtAddress,
                Email = txtEmail,
                Phone = Convert.ToInt32(txtPhone),
                DateIn = DateTime.Now
            });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateUser(string txtId,
                                        string txtName,
                                        string txtLastName,
                                        string txtPhone,
                                        string txtEmail,
                                        string txtAddress)
        {
            DatabaseHelper.DatabaseHelper.UpdateUser(new Models.User()
            {
                Id = Convert.ToInt16(txtId),
                Name = txtName,
                LastName = txtLastName,
                Address = txtAddress,
                Email = txtEmail,
                Phone = Convert.ToInt32(txtPhone)                
            });

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}