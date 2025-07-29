using Microsoft.AspNetCore.Mvc;
using Sandhata.eCommerce.Mvc.UI.Models;
using System.Diagnostics;

namespace Sandhata.eCommerce.Mvc.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("CustomerId", 1);
            return View();
        }
        //
       
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
