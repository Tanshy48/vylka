(function($) {
    'use strict'

    //по дефолту ховаємо кнопки з галочкою
    $('.iconTickBtn').each(function() {
        $(this).hide()
    })

    //відправляємо товар у кошик
    $( '.button' ).on('click', function(event) {
        const btn = $(this)
        const orderBtnDiv = $(this).parent()
        const itemId = orderBtnDiv.find('#itemId').val()

        $.ajax({
            type: 'POST',
            url: '/Products/AddToCart',
            data: { Id: itemId},
            success: function () {
                btn.children('#textBtn').text(' В кошику')
                btn.css('background-color', '#1f8657')
                btn.children('.iconCartBtn').hide()
                btn.children('.iconTickBtn').show()
            },
            error: function (e) {
                console.log(e);
            }
        })
    })

})(jQuery);