using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskTwo.Models;

namespace TaskTwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<PizzaModel> db;

        public HomeController(ILogger<HomeController> logger)
        {
            db = new Repository();
            _logger = logger;
        }

        [HttpGet]
        public JsonResult PizzaGetAll ()
        {
            var model = db.PizzaGetAll();

            return Json(model);
        }

        public IActionResult Index()
        {
            var model = db.PizzaGetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = db.FindById(id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View(PizzaGetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
