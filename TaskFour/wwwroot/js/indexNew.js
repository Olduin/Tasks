$('.card-name').on('click', function (e) {
    const $card = $(this).closest('.flex-card');
    const pizza = {
        name: $(this).text(),
        image: $card.find('.card-img').attr('src'),
        ingredients: $card.find('.card-ingredients').text(),
        price: $card.find('.card-price').text(),
        weight: $card.find('.card-weight').text()
    };
    ShowPizza(pizza);
});

$('.card-img').on('click', function (e) {
    const pizzaId = $(this).data('id');
    $.ajax({
        url: '/Home/GetPizzaById',
        type: 'GET',
        dataType: "json",
        data: { id: pizzaId },
        success: function (pizza) {
            if (pizza.error) {
                alert(pizza.error);
                return;
            }
            ShowPizza(pizza);
        },
        error: function () {
            alert('Ошибка при получении данных о пицце.');
        }
    })
});

function ShowPizza(pizza) {
    $('#pizzaModalLabel').text(pizza.name);
    $('#modalImg').attr('src', pizza.image);
    $('#modalIngredients').text(pizza.ingredients);
    $('#modalPrice').text(pizza.price);
    $('#modalWeight').text(pizza.weight);
    $('#pizzaModal').modal('show');
}

$('.button-link-Edit').on('click', function () {
    var pizzaId = $(this).data('id');
    if (pizzaId) {
        var url = 'PizzaEdit/' + encodeURIComponent(pizzaId);

        location.href = url;
    }
    else {
        location.href = 'PizzaEdit/';
    }
});

$('.button-link-Delete').on('click', function (e) {
    const pizzaId = $(this).data('id');
    let IsDelete = confirm("Удалить элемент?");
    if (IsDelete == true) {
        $.ajax({
            url: '/Home/PizzaDelete',
            type: 'POST',
            data: { id: pizzaId },
            success: function () {
                window.location.reload();
            },
            error: function () {
                alert('Ошибка при получении данных о пицце.');
            }
        })
    }
})