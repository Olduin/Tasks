using TaskTwo.Models;

namespace TaskTwo
{
    public class Repository
    {
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
            return pizzas;
        }
    }
}


