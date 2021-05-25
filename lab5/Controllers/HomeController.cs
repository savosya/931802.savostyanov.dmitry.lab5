using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab5.Controllers
{
    public class HomeController : Controller
    {

        //private AppDbContext _appDb;
        //public HomeController(AppDbContext context)
        //{
        //    _appDb = context;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
