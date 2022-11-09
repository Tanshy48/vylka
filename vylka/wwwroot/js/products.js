(function($) {
    'use strict'

    console.log("Value saved is: "+ localStorage.getItem($('.button')));
    //по дефолту ховаємо кнопки з галочкою
    $('.iconTickBtn').each(function() {
        $(this).hide()
    })

    //змінюємо стиль кнопки, на якій відбувся клік
    $( '.button' ).on('click', function(event) {
        event.preventDefault()
        $(this).css('background-color', '#1f8657')
        $(this).children('#textBtn').text(' В кошику')
        $(this).children('.iconCartBtn').hide()
        $(this).children('.iconTickBtn').show()
    })

})(jQuery);