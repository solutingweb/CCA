

function lista(tipo) {
    $('#ddlTipoEstado option').remove();
    if (tipo == 1) {
        $('#ddlTipoEstado').append('<option value="0" ">Todos...</option>');
        $('#ddlTipoEstado').append('<option value="1" ">No</option>');           
    }
} 