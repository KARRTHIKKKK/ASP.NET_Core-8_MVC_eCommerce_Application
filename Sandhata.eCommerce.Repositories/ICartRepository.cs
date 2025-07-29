using Sandhata.eCommerce.Models;
namespace Sandhata.eCommerce.Repositories;

public interface ICartRepository
{
    Task<List<YourCartVM>> GetYourCartItemsAsync(int cartId);   
}
