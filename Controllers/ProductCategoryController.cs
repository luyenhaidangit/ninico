using Microsoft.AspNetCore.Mvc;

namespace Ninico.Controllers
{
    public class ProductCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
