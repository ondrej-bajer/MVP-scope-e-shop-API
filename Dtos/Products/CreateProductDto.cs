using MVP_scope_e_shop_API.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace MVP_scope_e_shop_API.Dtos.Products
{
    [Product_CorrectSizing] // cross-field validation
    public class CreateProductDto : IProductSizing
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [Required, StringLength(60, MinimumLength = 2)]
        public string Brand { get; set; } = "";

        [Required, StringLength(30, MinimumLength = 2)]
        public string Color { get; set; } = "";

        [Range(1, 300)]
        public int Size { get; set; }

        [Required, StringLength(20)]
        [RegularExpression("^(men|women)$", ErrorMessage = "Gender must be 'men' or 'women'.")]
        public string Gender { get; set; } = "";

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; } = "";
    }
}
