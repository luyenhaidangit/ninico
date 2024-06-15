using Ninico.Models.Components.Header;

namespace Ninico.Models.Home
{
    public class HomeViewModel
    {
        public List<SlideHomeViewModel>? DynamicSlides { get; set; }

        public List<SlideHomeViewModel>? StaticSlides { get; set; }

        public List<ProductCategoryHomeViewModel> ProductCategories { get; set; }
    }
}
