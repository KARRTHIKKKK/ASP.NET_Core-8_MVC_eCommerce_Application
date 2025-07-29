using Microsoft.AspNetCore.Mvc;
using Sandhata.eCommerce.Models;
using Sandhata.eCommerce.Repositories;

namespace Sandhata.eCommerce.Mvc.UI.Areas.Products.Controllers
{
    [Area("Products")]

    public class HomeController : Controller
    {
        private readonly ICommonRepository<Product> _productRepository;
        public HomeController(ICommonRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        //Show Products List
        public async Task<IActionResult> Index()//Index.cshtml
        {
            ViewBag.PageTitle = "ASP .NET eCommerce Products List!";
            ViewBag.PageDescription = "Welcome To Products List  \n " +
                "This is the Products list of our ASP .NET Application";
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }
        //Show Category Wise Products
        public async Task<IActionResult> CategoryWiseProducts(int categoryId) //Index.cshtml in CategoriesView
        {
            ViewBag.PageTitle = "ASP .NET eCommerce Products List!";
            ViewBag.PageDescription = "This is the Products list of our eCommerce Application";
            var products = await _productRepository.GetAllAsync();
            var categoryProducts=products.Where(p => p.CategoryId == categoryId).ToList();
            return View("Index",categoryProducts);
        }
        //Show Product Details
        public async Task<IActionResult> Details(int id) //Details.cshtml
        {
            var product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }

    }
}
