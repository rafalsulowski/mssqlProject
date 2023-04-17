using Microsoft.AspNetCore.Mvc;
using mssqlProject.Web.Models;
using System.Diagnostics;

namespace mssqlProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ShowGrid", "Budget", new RouteValueDictionary(
    new { SortOrder = "Id", CurrentSort = "Id", doFilter = 0, minSH = 0, maxSH = 1000, minBS = 0, maxBS = 100000000 })) ;
        }

        public IActionResult Privacy()
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