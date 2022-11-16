(function($) {
    'use strict'
    
    window.jsPDF = window.jspdf.jsPDF;
    
    $('.pdfDownloader').click( function()  {
        MakePDFFile($(this))
    })
    
    function MakePDFFile(btn) {
        let doc = new jsPDF()
        doc.addFont("../fonts/arial.ttf", "arial", "normal")
        doc.setFont("arial")
        
        const parent = btn.parent().parent()
        const id = parent.find('#id').html()
        const date = parent.find('#date').html()
        const district = parent.find('#district').html()
        const city = parent.find('#city').html()
        const address = parent.find('#address').html()
        const delivery = parent.find('#delivery').html()
        const user = parent.find('#user').html()
        const price = parent.find('#price').html()

        doc.addImage('../images/favicon/favicon.png', 'PNG', 85, 20, 40, 40);
        doc.setFontSize(12)
        doc.text(85, 70, `VYLKA - Замовлення ${id}`)
        doc.setFontSize(10)
        doc.text(20, 90, `Дата оформлення замовлення: ${date}.`)
        doc.text(20, 100, `Адреса: ${district}, ${city}, ${address}.`)
        doc.text(20, 110, `Доставка: ${delivery}.`)
        doc.text(120, 120, `До сплати: ${price}`)
        doc.text(120, 130, `Замовник: ${user}`)
        doc.setFontSize(16)
        doc.text(50, 150, `Дякуємо, що користуєтесь нашим сервісом!`)
        
        doc.save('order'+id+'.pdf')
    }

})(jQuery);
