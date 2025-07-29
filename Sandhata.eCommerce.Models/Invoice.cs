namespace Sandhata.eCommerce.Models;

public class Invoice
{
    public int InvoiceId { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;
}
