(function($) {
    'use strict'

    //функції рахунку загальної кількості грошей
    const totalMoney = $( '#totalAmount' )
    let money = 0
    $('.price').each(function() {
        money += +($(this).html()) * +($(this).parent().parent().find('.countNum').html())
    })
    totalMoney.html(money)

    //зміна кількості товару
    $(".counter input[type=button]").click( function () {
        changeQuantity($(this))
    })

    function changeQuantity(OperationBtn) {
        const counterDiv = OperationBtn.parent()
        let itemQuantity = counterDiv.find('.countNum')
        const itemId = counterDiv.find('#itemId').val()
        const operation = counterDiv.find(OperationBtn).val()
        const cardDiv = counterDiv.parent()
        const itemPrice = cardDiv.find('.price').text()

        $.ajax({
            type: 'POST',
            url: '/ShoppingCart/ChangeQuantity',
            data: { Id: itemId, Operation: OperationBtn.val()},
            success: function () {
                if( operation === '+') {
                    itemQuantity.text(+itemQuantity.text() + 1)
                    money += +itemPrice
                    totalMoney.html(money)
                } else {
                    if (+itemQuantity.text() > 1) {
                        itemQuantity.text(+itemQuantity.text() - 1)
                        money -= +itemPrice
                        totalMoney.html(money)
                    }
                }
            },
            error: function (e) {
                console.log(e);
            }
        })
    }

    //розкриття форми
    /*$( '#toggler' ).click( (e) => {
        e.preventDefault();
        $('.total').toggleClass('toggled');
    })*/

    //видалення товару із корзини
    $( '.delBtn' ).on('click', function() {
        const itemDiv = $(this).parent()
        const itemId = itemDiv.find('.counter #itemId').val()
        const itemPrice = itemDiv.find('.price').text()
        const itemQuantity = itemDiv.find('.counter .countNum').text()
        
        $.ajax({
            type: 'POST',
            url: '/ShoppingCart/Delete',
            data: { Id: itemId },
            success: function () {
                itemDiv.remove()
                money -= +itemPrice * +itemQuantity
                totalMoney.html(money)
            },
            error: function (e) {
                console.log(e);
            }
        })

        //
        $( '#submitBtn' ).click( function() {
            $.cookie('totalPrice', $('#totalAmount').html());
           /* window.location.href = 'NewOrder';*/
            console.log(window.location)
            /*window.location = '/ShoppingCart/NewOrder?val' + $('#totalAmount').html()*/
        })
    })
    
})(jQuery);