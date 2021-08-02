function CarritoGrabar() {
    debugger
    $.ajax({
        url: '/Apunte/GrabarCarrito/',
        type: 'POST',
        async: false,
        dataType: 'json',
        processData: false,
        data: {},
        success: function (result) {
            if (result.Mensaje == 'Venta Carrito OK') {
               Swal.fire({
                    title: 'Venta Realizada',
                    icon: 'question',
                    timer: 5000,
                    timerProgressBar: true,                   
                    confirmButtonText: '¡Sí!',
                                 
                })
                $(location).attr('href', '/Apunte/Listar');
            }
            else {
                console.log("Error");
                Swal.fire({
                    title: 'Error!',
                    text: 'Error:' + result.Mensaje,
                    icon: 'error',
                })
                $(location).attr('href', '/Apunte/Listar');
            }           
        }        
    });
}


function VaciarCarrito() {
    debugger
    Swal.fire({
        title: '¿Está seguro que desea vaciar el carrito?',
        text: "¡Si lo vacía, no lo puede volver a recuperar!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '¡Sí!',
        cancelButtonText: 'No'
    })
        .then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Apunte/VaciarCarrito/',
                    data: {},
                    type: 'POST',
                    success: function (results) {
                        $(location).attr('href', '/Apunte/AgregarCarrito');
                    }
                });
            } else {
                Swal.fire({
                    title: 'Error',
                    text: 'Error:' + result.mensaje,
                    icon: 'error',
                    timer: 150000,
                })
                $(location).attr('href', '/Apunte/Listar');
            }
        });
}

