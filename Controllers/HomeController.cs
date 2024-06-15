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

            var viewModel = new HomeViewModel()
            {
                DynamicSlides = dynamicSlides,
                StaticSlides = staticSlides
            };

            return View(viewModel);
        }
    }
}
