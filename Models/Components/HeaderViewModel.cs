using Ninico.Data.Entities;
using Ninico.Models.ProductCategory;

namespace Ninico.Models.Components
{
    public class HeaderViewModel
    {
        public string Logo { get; set; }

        public string Phone { get; set; }

        public List<ProductCategoryHeaderViewModel>? ProductCategories { get; set; }
    }
}
