namespace Ninico.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        public string? Banner { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public string SKU { get; set; }

        public string Tags { get; set; }

        public int ProductCategoryId { get; set; }
    }
}
