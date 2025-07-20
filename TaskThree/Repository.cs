using TaskThree.Models;

namespace TaskThree
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> PizzaGetAll();
        T FindById(int id);

    }
    public class Repository : IRepository<PizzaModel>
    {
        private readonly ILogger<Repository> _logger;

        public Repository(ILogger<Repository> logger)
        {
            _logger = logger;
        }

        List<PizzaModel> pizzas = new List<PizzaModel>()
        {
            new PizzaModel()
            {
                Id = 1,
                Name = "Capriccio",
                Image = @"\images\capriccio_1.jpg",
                Ingredients = "Сыр моцарелла, Соус \"Барбекю\", Соус \"Кальяри\", Пепперони, Овощи гриль, Бекон, Ветчина",
                Price = 740,
                Weight = "980"
            },
            new PizzaModel()
            {
                Id = 2,
                Name = "XXXL",
                Image = @"\images\xxxl_1.jpg",
                Ingredients = "Сыр моцарелла, Соус \"1000 островов\", Куриный рулет, Ветчина, Колбаски охотничьи, Бекон, Сервелат, Огурцы маринованные",
                Price = 880,
                Weight = "1440"
            },
            new PizzaModel()
            {
                Id= 3,
                Name = "4 вкуса",
                Image = @"\images\4_vkusa_1.jpg",
                Ingredients = "Соус \"1000 островов\", Сыр моцарелла, Рулет куриный, Ветчина, Пепперони, Сыр пармезан",
                Price = 530,
                Weight = "540"
            },
            new PizzaModel()
            {
                Id= 4,
                Name = "Амазонка",
                Image = @"\images\amazonka_1.jpg",
                Ingredients = "Соус \"Томатный\", Сыр моцарелла, Куриная грудка, Брокколи, Огурцы маринованные",
                Price = 550,
                Weight = "600"
            },
            new PizzaModel()
            {
                Id= 5,
                Name = "БананZZа",
                Image = @"\images\bananzza_1.jpg",
                Ingredients = "Бананы, Соус \"Гавайский\", Сыр моцарелла, Ананас, Шоколад молочный, Кокос/миндаль, Топпинг клубничный",
                Price = 420,
                Weight = "520"
            },
            new PizzaModel()
            {
                Id= 6,
                Name = "Барбекю",
                Image = @"\images\barbeq_1.jpg",
                Ingredients = "Соус \"Томатный\", Сыр моцарелла, Ветчина, Бекон, Пепперони, Соус \"Барбекю\", Томаты, Перец болгарский, Лук маринованный",
                Price = 450,
                Weight = "590"
            },
            new PizzaModel()
            {
                Id= 7,
                Name = "Буритто",
                Image = @"\images\buritto_1.jpg",
                Ingredients = "Соус \"Томатный острый\", Сыр моцарелла, Куриная грудка, Кукуруза, Фасоль консервированная, Соус сырный \"Пармеджано\", Перец болгарский, Лук маринованный",
                Price = 450,
                Weight = "550"
            },
            new PizzaModel()
            {
                Id= 8,
                Name = "Гавайская",
                Image = @"\images\hawai_1.jpg",
                Ingredients = "Ветчина, Соус \"Гавайский\", Сыр моцарелла, Ананас, Перец болгарский",
                Price = 450,
                Weight = "590"
            }

        };

        public List<PizzaModel> PizzaGetAll()
        {
            _logger.LogInformation("Выполнен запрос на получение всех пицц. Количество: {Count}", pizzas.Count);
            return pizzas;
        }

        public PizzaModel FindById(int id)
        {
            _logger.LogInformation("Выполнен запрос на получение пиццы по ID: {Id}", id);
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
            {
                _logger.LogWarning("Пицца с ID {Id} не найдена", id);
            }
            else
            {
                _logger.LogInformation("Пицца найдена: {Name}, Цена: {Price}", pizza.Name, pizza.Price);
            }
            return pizza;
        }

        public void Dispose()
        {
            _logger.LogInformation("Repository disposed");
        }
    }
}


