using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskTwo.Models;

namespace TaskTwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<PizzaModel> _repository;

        public HomeController(ILogger<HomeController> logger, IRepository<PizzaModel> repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult PizzaGetAll ()
        {
            _logger.LogInformation("Запрошен список всех пицц (JSON)");
            try 
            {
                var pizzas = _repository.PizzaGetAll();
                if (pizzas == null)
                {
                    _logger.LogWarning("Пиццы не найдены (PizzaGetAll вернул null)");
                    return Json(new { error = "Пицца не найдена" });
                }
                return Json(pizzas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении списка пицц");
                return Json(new { error = "Произошла ошибка на сервере" });
            }                                   
        }

        [HttpGet]
        public JsonResult GetPizzaById(int id)
        {
            _logger.LogInformation("Запрошена пицца по ID: {PizzaId}", id);
            try
            {
                var pizza = _repository.FindById(id);
                if (pizza == null)
                {
                    _logger.LogWarning("Пицца с ID {PizzaId} не найдена", id);
                    return Json(new { error = "Пицца не найдена" });
                }

                return Json(pizza);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении пиццы по ID {PizzaId}", id);
                return Json(new { error = "Произошла ошибка на сервере" });
            }
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Открыта главная страница Index");
            try
            {
                var model = _repository.PizzaGetAll();
                return View(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка при выполнения Index");
                throw;
            }           
        }

        public IActionResult IndexNew()
        {
            _logger.LogInformation("Открыта страница IndexNew");
            try
            {
                var model = _repository.PizzaGetAll();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в IndexNew");
                return View("Error");
            }
        }

        public IActionResult Details(int id)
        {
            _logger.LogInformation("Просмотр пиццы с ID: {PizzaId}", id);
            try
            {
                var model = _repository.FindById(id);
                if (model == null)
                {
                    _logger.LogWarning("Пицца с ID {PizzaId} не найдена в Details", id);
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка в Details при ID {PizzaId}", id);
                return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View(PizzaGetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError("Произошла ошибка. RequestId: {RequestId}", requestId);
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
