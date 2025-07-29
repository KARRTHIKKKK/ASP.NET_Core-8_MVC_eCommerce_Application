namespace Sandhata.eCommerce.Models;

public class YourCartVM
{
    public int CartId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string Picture { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int Size { get; set; }
    public double TotalPrice => Price * Quantity;
}
