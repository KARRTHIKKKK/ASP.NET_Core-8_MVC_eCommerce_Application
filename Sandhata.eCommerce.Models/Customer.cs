using System.ComponentModel.DataAnnotations;

namespace Sandhata.eCommerce.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "Customer name is required field!")]
    [MaxLength(100, ErrorMessage = "Customer name can not exceed 100 characters!")]
    [Display(Name = "Contact Name")]
    public string ContactName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Customer address is required field!")]
    [Display(Name = "Address")]
    [MaxLength(500, ErrorMessage = "Customer address can not exceed 500 characters!")]
    public string Address { get; set; } = string.Empty;
    [Required(ErrorMessage = "Customer city is required field!")]
    [MaxLength(100, ErrorMessage = "Customer city can not exceed 100 characters!")]
    [Display(Name = "City")]
    public string City { get; set; } = string.Empty;
    [Required(ErrorMessage = "Customer phone number is required field!")]
    [MaxLength(20, ErrorMessage = "Customer phone number can not exceed 20 characters!")]
    [Display(Name = "Contact #")]
    public string Phone { get; set; } = string.Empty;
    [EmailAddress(ErrorMessage = "Email must be in correct format. For Ex. - john@myshoeworld.com")]
    [MaxLength(100, ErrorMessage = "Customer email can not exceed 100 characters!")]
    [Display(Name = "Email Id")]
    public string Email { get; set; } = string.Empty;
    public ICollection<Cart>? Carts { get; set; }
}
