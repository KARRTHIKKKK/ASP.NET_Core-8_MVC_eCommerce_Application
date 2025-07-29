
using Microsoft.EntityFrameworkCore;
using Sandhata.eCommerce.Models;

namespace Sandhata.eCommerce.Repositories;

public class CartRepository : ICartRepository
{
    private readonly SandhataDbContext _context;
    public CartRepository(SandhataDbContext context)
    {
        _context = context;
    }

    public async Task<List<YourCartVM>> GetYourCartItemsAsync(int cartId)
    {
        var cartItems = from cart in _context.Carts
                        join
                        cartItem in _context.CartDetails
                        on cart.CartId equals cartItem.CartId
                        join
                        product in _context.Products
                        on cartItem.ProductId equals product.ProductId
                        join
                        Category in _context.Categories
                           on product.CategoryId equals Category.CategoryId
                        where cart.CartId == cartId
                        select new YourCartVM
                        {
                            CartId = cart.CartId,
                            CategoryName = Category.CategoryName,
                            ProductName = product.ProductName,
                            Picture = product.Picture,
                            Price = product.UnitPrice,
                            Quantity = cartItem.Quantity,
                            Size = cartItem.Size
                        };
        return await cartItems.ToListAsync();
    }
}
