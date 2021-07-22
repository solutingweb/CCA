function CarritoGrabar() {
    $.ajax({
        url: '/Apunte/GrabarCarrito/',
        type: 'POST',
        async: false,
        dataType: 'json',
        processData: false,
        data: {},
        success: function (result) {
            if (result.Mensaje == 'Venta Carrito OK') {
                swal({
                    title: "Carga Satisfactoria",
                    text: "Haga clic en el boton",
                    icon: "success",
                    timer: 10000,
                });
                
            }
            else {
                console.log("Error");
                swal({
                    title: "Error!!! " + result.Mensaje,
                    text: "Haga clic en el Boton",
                    icon: "Error",
                    timer: 10000,
                });
            }
            $(location).attr('href', '/Apunte/Index');
        }
    });
}