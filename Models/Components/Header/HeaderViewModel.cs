using Ninico.Data.Entities;

namespace Ninico.Models.Components.Header
{
    public class HeaderViewModel
    {
        public string Logo { get; set; }

        public string Phone { get; set; }

        public List<ProductCategoryHeaderViewModel>? ProductCategories { get; set; }
    }
}
