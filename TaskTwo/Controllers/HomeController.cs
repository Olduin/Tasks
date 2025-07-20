using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskTwo.Models;

namespace TaskTwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<PizzaModel> db;

        public HomeController(ILogger<HomeController> logger, IRepository<PizzaModel> repository)
        {
            db = repository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult PizzaGetAll ()
        {
            _logger.LogInformation("�������� ������ ���� ���� (JSON)");
            try 
            {
                var pizzas = db.PizzaGetAll();
                if (pizzas == null)
                {
                    _logger.LogWarning("����� �� ������� (PizzaGetAll ������ null)");
                    return Json(new { error = "����� �� �������" });
                }
                return Json(pizzas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "������ ��� ��������� ������ ����");
                return Json(new { error = "��������� ������ �� �������" });
            }                                   
        }

        [HttpGet]
        public JsonResult GetPizzaById(int id)
        {
            _logger.LogInformation("��������� ����� �� ID: {PizzaId}", id);
            try
            {
                var pizza = db.FindById(id);
                if (pizza == null)
                {
                    _logger.LogWarning("����� � ID {PizzaId} �� �������", id);
                    return Json(new { error = "����� �� �������" });
                }

                return Json(pizza);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "������ ��� ��������� ����� �� ID {PizzaId}", id);
                return Json(new { error = "��������� ������ �� �������" });
            }
        }

        public IActionResult Index()
        {
            _logger.LogInformation("������� ������� �������� Index");
            try
            {
                var model = db.PizzaGetAll();
                return View(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "������ ��� ���������� Index");
                throw;
            }           
        }

        public IActionResult IndexNew()
        {
            _logger.LogInformation("������� �������� IndexNew");
            try
            {
                var model = db.PizzaGetAll();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "������ � IndexNew");
                return View("Error");
            }
        }

        public IActionResult Details(int id)
        {
            _logger.LogInformation("�������� ����� � ID: {PizzaId}", id);
            try
            {
                var model = db.FindById(id);
                if (model == null)
                {
                    _logger.LogWarning("����� � ID {PizzaId} �� ������� � Details", id);
                    return NotFound();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "������ � Details ��� ID {PizzaId}", id);
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
            _logger.LogError("��������� ������. RequestId: {RequestId}", requestId);
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
