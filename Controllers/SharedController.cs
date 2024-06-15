using Microsoft.AspNetCore.Mvc;
using Ninico.Data.EntityFrameworkCore;

namespace Ninico.Controllers
{
    public class SharedController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            return View();
        }
    }
}
