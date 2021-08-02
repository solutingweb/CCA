function ValidarUsuario()
{
    debugger

    $.ajax({
        url: '/Home/Inicio',
        type: 'POST',
        async: false,
        dataType: 'text',
        processData: false,
        data: $('#FrmLogin').serialize(),
        success: function (data) {
            var resultado = $.parseJSON(data);
            if (resultado.Mensaje !== '') {
                $('#msgErrorLogin').show('slow');
                $('#msgErrorLoginDes').append(resultado.Mensaje);
            }
            else {
                window.location = "/Usuario/Listar";
            }

        }
    });
}