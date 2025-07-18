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
            var pizzas = db.PizzaGetAll();
            if (pizzas == null)
            {
                return Json(new { error = "Пицца не найдена" });
            }

            return Json(pizzas);
        }

        [HttpGet]
        public JsonResult GetPizzaById(int id)
        {
            var pizza = db.FindById(id);
            if (pizza == null)
            {
                return Json(new { error = "Пицца не найдена" });
            }
            return Json(pizza);
        }

        public IActionResult Index()
        {
            var model = db.PizzaGetAll();
            return View(model);
        }

        public IActionResult IndexNew()
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
