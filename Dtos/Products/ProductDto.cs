namespace MVP_scope_e_shop_API.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Color { get; set; } = "";

        public int Size { get; set; }

        public string Gender { get; set; } = "";

        public decimal Price { get; set; }

        public string Description { get; set; } = "";
    }
}
