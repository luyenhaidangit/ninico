using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ninico.Data.EntityFrameworkCore;
using Ninico.Models.Components.Header;
using Ninico.Models.Home;

namespace Ninico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public int SlideTypeDynamic = 1;
        public int SlideTypeStatic = 2;
        public int MaxSlideTypeDynamic = 5;
        public int MaxTypeStatic = 2;
        public int MaxProductCategory = 6;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            //Title
            ViewBag.Title = "Ninico - Thương hiệu thời trang";

            //Slides
            var dynamicSlides = await _dbContext.Slides
                .Where(x => x.Type == SlideTypeDynamic)
                .Select(pc => new SlideHomeViewModel
                {
                    Image = pc.Image,
                    Content = pc.Content,
                })
                .Take(MaxSlideTypeDynamic)
                .ToListAsync();

            var staticSlides = await _dbContext.Slides
                .Where(x => x.Type == SlideTypeStatic)
                .Select(pc => new SlideHomeViewModel
                {
                    Image = pc.Image,
                    Content = pc.Content,
                })
                .Take(MaxTypeStatic)
                .ToListAsync();

            //Product categories
            var productCategories = await _dbContext.ProductCategories
                .Include(pc => pc.Childrens)
                .Where(pc => pc.ParentId == null)
                .OrderByDescending(pc => pc.Order)
                .Select(pc => new ProductCategoryHomeViewModel
                {
                    Name = pc.Name,
                    Slug = pc.Slug,
                    Image = pc.Image,
                    ProductCount = pc.Products.Count(),
                })
                .Take(MaxProductCategory)
                .ToListAsync();


            var viewModel = new HomeViewModel()
            {
                DynamicSlides = dynamicSlides,
                StaticSlides = staticSlides,
                ProductCategories = productCategories,
            };

            return View(viewModel);
        }
    }
}
