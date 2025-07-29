using System.ComponentModel.DataAnnotations;

namespace Sandhata.eCommerce.Models;

public class Category
{
    //    public int CategoryId { get; set; }
    //    public string CategoryName { get; set; } = string.Empty;
    //    public string CategoryDescription { get; set; } = string.Empty;

    [Key]
    public int CategoryId { get; set; }
    [Display(Name = "Category Name")]
    [Required(ErrorMessage = "Category name is required.")]
    [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
    public string CategoryName { get; set; } = string.Empty;
    [Display(Name = "Category Description")]
    [Required(ErrorMessage = "Category description is required.")]
    [MaxLength(500, ErrorMessage = "Category description cannot exceed 500 characters.")]
    public string CategoryDescription { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; }
}
