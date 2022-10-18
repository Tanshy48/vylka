(function($) {
    "use strict";
  
    //To get footer to the end of page
    $(".render-content").css('min-height', $(window).height()-$("footer").height()-$("nav").height());
    
})(jQuery);