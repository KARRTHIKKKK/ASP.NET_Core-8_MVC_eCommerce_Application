using System.ComponentModel.DataAnnotations;

namespace Sandhata.eCommerce.Models;

public class CartDetail
{
    [Key]
    public int CartItemId { get; set; }
    public int Quantity { get; set; } = 1;
    public int Size { get; set; } = 7;
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public Cart Cart { get; set; }
    public Product Product { get; set; }
}
