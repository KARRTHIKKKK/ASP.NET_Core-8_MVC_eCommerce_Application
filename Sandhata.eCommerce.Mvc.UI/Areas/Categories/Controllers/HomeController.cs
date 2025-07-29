using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sandhata.eCommerce.Models;
using Sandhata.eCommerce.Repositories;

namespace Sandhata.eCommerce.Mvc.UI.Areas.Categories.Controllers;
[Area("Categories")]

public class HomeController : Controller
{
    private readonly ICommonRepository<Category> _categoryRepository;
    private readonly IMemoryCache _memoryCache; 
    public HomeController(ICommonRepository<Category> categoryRepository, IMemoryCache memoryCache)
    {
        _categoryRepository = categoryRepository;
        _memoryCache = memoryCache;
    }
    public async Task<IActionResult> Index()
    {
        //ViewBag.PageTitle = "Sandhata eCommerce Categories List!";
        ViewBag.PageTitle = "ASP .NET eCommerce Categories List!";
        ViewBag.PageDescription = "Welcome To Categories List ";
        //var categories=await _categoryRepository.GetAllAsync();
        if (_memoryCache.TryGetValue("CategoriesCache", out IEnumerable<Category> categories))
        {
            return View(categories);
        }
        else
        {
            categories = await _categoryRepository.GetAllAsync();
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                SlidingExpiration = TimeSpan.FromMinutes(10),
            };
            _memoryCache.Set("CategoriesCache", categories, cacheOptions);
            return View(categories);
        }
        
    }
    [Authorize(Roles ="Admin")]
    public IActionResult Create() 
    {
        return View();
    }
    [Authorize(Roles = "Admin")]

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (ModelState.IsValid)
        {
            var result = await _categoryRepository.AddAsync(category);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Failed to create category. Please try again.");
            }
        }
        return View();
    }
}
