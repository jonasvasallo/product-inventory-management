using System.ComponentModel.DataAnnotations;

namespace Product.InventoryManagement.BlazorUI.Models
{
    public class UpdateProductFormModel : ProductFormModel
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public int Id { get; set; }
    }
}
