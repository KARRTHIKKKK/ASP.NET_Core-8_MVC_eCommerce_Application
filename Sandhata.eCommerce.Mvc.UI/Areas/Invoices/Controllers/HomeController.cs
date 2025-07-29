using Microsoft.AspNetCore.Mvc;

namespace Sandhata.eCommerce.Mvc.UI.Areas.Invoices.Controllers
{
    [Area("Invoices")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
