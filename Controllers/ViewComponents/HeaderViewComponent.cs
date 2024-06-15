using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ninico.Data.EntityFrameworkCore;
using Ninico.Helpers;
using Ninico.Models.Components;
using Ninico.Models.ProductCategory;

namespace Ninico.Controllers.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;

        public string LogoKeyConfig = "Logo";
        public string PhoneKeyConfig = "Phone";
        public int MaxProductCategory = 7;

        public HeaderViewComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var logo = await _dbContext.Configs.FindAsync(LogoKeyConfig);

            var phone = await _dbContext.Configs.FindAsync(PhoneKeyConfig);

            var productCategories = await _dbContext.ProductCategories
                .Include(pc => pc.Childrens)
                .Where(pc => pc.ParentId == null)
                .OrderByDescending(pc => pc.Order)
                .Select(pc => new ProductCategoryHeaderViewModel
                {
                    Name = pc.Name,
                    Slug = pc.Slug,
                    Icon = pc.Icon,
                    Childrens = pc.Childrens.Select(c => new ProductCategoryHeaderViewModel
                    {
                        Name = c.Name,
                        Slug = c.Slug,
                        Icon = c.Icon
                    }).ToList()
                })
                .Take(7)
                .ToListAsync();

            var viewModel = new HeaderViewModel()
            {
                Logo = logo.Value,
                Phone = phone.Value,
                ProductCategories = productCategories
            };

            return View(viewModel);
        }
    }
}
