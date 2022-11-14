(function($) {
    'use strict'
    
    if ($.cookie('totalPrice') != null) {
        let data = $.cookie('totalPrice');
        $('#totalAmountInOrder').html(data);
        $.removeCookie('totalPrice');
    }
    
})(jQuery);