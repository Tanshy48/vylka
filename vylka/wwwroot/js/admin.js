(function($) {
  'use strict'

  //Toggle function of navigation sidebar
  $('#sidebarToggle').on('click',(e) => {
      e.preventDefault();
      $('body').toggleClass('sidebar-toggled');
      $('.sidebar').toggleClass('toggled');
    })
  
  //To make width of the table title div the same as width of element of the table
  $('.bg-table-title').css('min-width', $('table').width())

  $('#delCheckBox').click(() => {
    if ($('#delCheckBox').is(':checked')) {
      $('#sendFormBtn').attr('disabled', false);
    } else {
      $('#sendFormBtn').attr('disabled', true);
    }
  })

})(jQuery);
