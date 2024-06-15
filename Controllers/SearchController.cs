using Microsoft.AspNetCore.Mvc;

namespace Ninico.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
