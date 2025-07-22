    $('.card-img').on('click', function(){
            var pizzaId = $(this).data('id');
    if (pizzaId){
                var url='Home/Details/' + encodeURIComponent(pizzaId);

    location.href = url;
            }

        });

    $('.button-link-Edit').on('click', function(){
                var pizzaId = $(this).data('id');
    if (pizzaId){
                var url='Home/PizzaEdit/' + encodeURIComponent(pizzaId);

    location.href = url;
            }
    else{
        location.href = 'Home/PizzaEdit/';
            }
        });

    $('.button-link-Delete').on('click', function (e) {
                const pizzaId = $(this).data('id');
    let IsDelete = confirm("Удалить элемент?");
    if (IsDelete == true){
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


