(function($) {
    'use strict'
  
    //To get footer to the end of page
    $('.render-content')
        .css('min-height', $(window).height()-$('footer').height()-$('nav').height())
        .css('width','100%')

    
    $(window).scroll( () => {
        const testimonials = $('.testimonials')
        testimonials.addClass('animate__animated');
        testimonials.addClass('animate__fadeInUp');
    })
    
})(jQuery);