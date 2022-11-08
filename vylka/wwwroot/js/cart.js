(function($) {
    'use strict'

    let count = 1
    let money = 0
    //функції рахунку загальної кількості грошей, які повинен сплатити покупець
    $('.price').each(function() {
        money += +($(this).html())
    });
    $( '#totalAmount' ).html(money)

    $( '.products' ).on('click', '.plus', function(event) {
        event.preventDefault()
        count = +$(this).next().html() + 1
        $(this).next().html(count)

        money+= +($(this).parent().prev().find('.price').html())
        $( '#totalAmount' ).html(money)
    })
    $( '.products' ).on('click', '.minus', function(event) {
        if(+$(this).prev().html() > 1) {
            event.preventDefault()
            count = +$(this).prev().html() - 1
            $(this).prev().html(count)
            
            money-= +($(this).parent().prev().find('.price').html())
            $( '#totalAmount' ).html(money)
        }
    })

    //розкриття форми
    $( '#toggler' ).click( function(e) {
        e.preventDefault()
        $('.total').toggleClass('toggled')
    })

    //видалення товару із корзини
    $( '.delBtn' ).on('click', function(event) {
        event.preventDefault()
        $(this).parent().remove()
    })

})(jQuery);