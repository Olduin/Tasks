using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskFour;
using TaskFour.Models;

namespace TaskThree.Controllers
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
        public JsonResult PizzaGetAll()
        {
            _logger.LogInformation("�������� ������ ���� ���� (JSON)");
            try
            {
                var pizzas = _repository.PizzaGetAll();
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
                var pizza = _repository.PizzaGetById(id);
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
                var model = _repository.PizzaGetAll();
                return View(model);
            }
            catch (Exception ex)
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
                var model = _repository.PizzaGetAll();
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
                var model = _repository.PizzaGetById(id);
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

        [HttpGet]
        public IActionResult PizzaEdit(int? id)
        {
            PizzaModel pizza = new PizzaModel();
            if (id != null)
            {
                pizza = _repository.PizzaGetById(id);
            }
            return View(pizza);
        }

        [HttpPost]
        public IActionResult PizzaEdit(PizzaModel pizza)
        {
            if (ModelState.IsValid)
            {
                if (pizza.Id.HasValue)
                {
                    //����������
                    var item = _repository.PizzaGetById(pizza.Id.Value);
                    if (item != null)
                    {
                        item.Name = pizza.Name;
                        item.Ingredients = pizza.Ingredients;
                        item.Image = pizza.Image;
                        item.Weight = pizza.Weight;
                        item.Price = pizza.Price;
                    }
                }
                else
                {
                    //����������
                    var newItem = new PizzaModel(pizza);
                    _repository.PizzaAdd(newItem);
                }
                _repository.Save();
                return RedirectToAction("Index");

            }
            return View(pizza);
        }

        [HttpPost]
        public ActionResult PizzaDelete(int? id)
        {
            if (id != null)
            {
                _repository.PizzaDelete(id);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return NotFound();

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
