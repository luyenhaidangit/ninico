namespace Ninico.Models.ProductCategory
{
    public class ProductCategoryHeaderViewModel
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string? Icon { get; set; }

        public List<ProductCategoryHeaderViewModel>? Childrens { get; set; }
    }
}
