using MVP_scope_e_shop_API.Dtos.Products;
using MVP_scope_e_shop_API.Models;

namespace MVP_scope_e_shop_API.Mapping
{
    public static class ProductMapping
    {
        public static ProductDto ToDto(this Product p) => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Brand = p.Brand,
            Color = p.Color,
            Size = p.Size,
            Gender = p.Gender,
            Price = p.Price,
            Description = p.Description
        };

        public static Product ToEntity(this CreateProductDto dto) => new Product
        {
            Name = dto.Name.Trim(),
            Brand = dto.Brand.Trim(),
            Color = dto.Color.Trim(),
            Size = dto.Size,
            Gender = dto.Gender.Trim(),
            Price = dto.Price,
            Description = dto.Description?.Trim() ?? ""
        };

        public static void Apply(this UpdateProductDto dto, Product entity)
        {
            entity.Name = dto.Name.Trim();
            entity.Brand = dto.Brand.Trim();
            entity.Color = dto.Color.Trim();
            entity.Size = dto.Size;
            entity.Gender = dto.Gender.Trim();
            entity.Price = dto.Price;
            entity.Description = dto.Description?.Trim() ?? "";
        }
    }
}
