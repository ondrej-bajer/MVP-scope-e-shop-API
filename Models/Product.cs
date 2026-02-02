namespace MVP_scope_e_shop_API.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Color { get; set; } = null!;

        public int Size { get; set; }

        public string Gender { get; set; }

        public double Price { get; set; }

        public string  Description { get; set; }
    }
}
