using System.ComponentModel.DataAnnotations;

public class ProductFormModel
{
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(70, ErrorMessage = "Name must be under 100 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(200, ErrorMessage = "Description must be under 200 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0 and less than 999 million")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, 999, ErrorMessage = "Quantity cannot be negative and less than 999")]
    public int Quantity { get; set; }
}