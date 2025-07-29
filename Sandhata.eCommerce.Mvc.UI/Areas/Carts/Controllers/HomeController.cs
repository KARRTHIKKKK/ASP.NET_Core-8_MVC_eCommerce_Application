using Microsoft.AspNetCore.Mvc;
using Sandhata.eCommerce.Models;
using Sandhata.eCommerce.Repositories;

namespace Sandhata.eCommerce.Mvc.UI.Areas.Carts.Controllers;

[Area("Carts")]
public class HomeController : Controller
{
    private readonly ICommonRepository<Cart> _cartRepository;
    private readonly ICommonRepository<CartDetail> _cartDetailRepository;
    private readonly ICartRepository _cartViewRepository;


    public HomeController(ICommonRepository<Cart> cartRepository, ICommonRepository<CartDetail> cartDetailRepository, ICartRepository cartViewRepository)
    {
        _cartRepository = cartRepository;
        _cartDetailRepository = cartDetailRepository;
        _cartViewRepository = cartViewRepository;
    }

    public async Task<IActionResult> AddToCart(int productId)
    {
        if (HttpContext.Session.GetInt32("CartId") == null || HttpContext.Session.GetInt32("CartId") <= 0)
        {
            Cart cart = new Cart()
            {
                CartDate = DateTime.Now,
                CustomerId = HttpContext.Session.GetInt32("CustomerId") ?? 0
            };
            var result = await _cartRepository.AddAsync(cart);
            if (result > 0)
            {
                HttpContext.Session.SetInt32("CartId", cart.CartId);
            }
        }
        CartDetail cartDetail = new CartDetail()
        {
            CartId = HttpContext.Session.GetInt32("CartId") ?? 0,
            ProductId = productId,
            Quantity = 1, // Default quantity
            Size = 7 // Default size
        };
        var cartDetailResult = await _cartDetailRepository.AddAsync(cartDetail);
        if (cartDetailResult > 0)
        {
            return RedirectToAction("YourCart");
        }
        return View();
    }
    public async Task<IActionResult> YourCart()
    {
        if (HttpContext.Session.GetInt32("CartId") == null || HttpContext.Session.GetInt32("CartId") <= 0)
        {
            ViewBag.ErrorMessage = "Your cart is empty. Please add items to your cart before viewing it.";
            return View();
        }

        var yourCartItems = await _cartViewRepository.GetYourCartItemsAsync(HttpContext.Session.GetInt32("CartId") ?? 0);
        return View(yourCartItems);
    }
   
}
