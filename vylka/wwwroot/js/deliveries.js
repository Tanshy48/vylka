(function($) {
    'use strict'

    const deliveries = ['Нова пошта', 'Укрпошта']

    $.each(deliveries, function(index) {
        $('#deliverySelect').append(new Option(deliveries[index]))
    })

})(jQuery);
