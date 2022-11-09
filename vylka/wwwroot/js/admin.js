(function($) {
  'use strict'

  //Toggler function of navigation sidebar
  $('#sidebarToggle').on('click',function(e) {
    e.preventDefault()
    $('body').toggleClass('sidebar-toggled')
    $('.sidebar').toggleClass('toggled')
  });
  
  //To make width of the table title div the same as width of element of the table
  $('.bg-table-title').css('min-width', $('table').width());

  $('#delCheckBox').click(function() {
    if($('#delCheckBox').is(':checked')){
      $('#sendFormBtn').attr('disabled', false)
    } else {
      $('#sendFormBtn').attr('disabled', true)
    }
    console.log($('#delCheckBox').is(':checked'))
  });

})(jQuery);
