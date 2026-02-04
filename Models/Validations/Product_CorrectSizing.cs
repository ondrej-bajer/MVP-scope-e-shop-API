using System.ComponentModel.DataAnnotations;

namespace MVP_scope_e_shop_API.Models.Validations
{
    public class Product_CorrectSizing : ValidationAttribute
    {
        /// <summary>
        /// Cross validation: minimal size of product based on gender
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not IProductSizing model)
                return ValidationResult.Success;

            var gender = model.Gender?.Trim();

            if (string.IsNullOrWhiteSpace(gender))
                return ValidationResult.Success; // gender is required + value validation (men|women) 

            if (gender.Equals("men", StringComparison.OrdinalIgnoreCase) && model.Size < 44)
                return new ValidationResult("The size of men's products must be 44 or greater.");

            if (gender.Equals("women", StringComparison.OrdinalIgnoreCase) && model.Size < 32)
                return new ValidationResult("The size of women's products must be 32 or greater.");

            return ValidationResult.Success;
        }
    }
}
