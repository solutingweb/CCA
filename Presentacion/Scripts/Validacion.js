function Validacion() {
    document.getElementById("Errores").innerHTML = "";

    debugger
    var nombre = document.getElementById("NombreApunte").value;
    var apellido = document.getElementById("Estado").value;
    var documento = document.getElementById("Digitalizado").value;   
    var valido = true;

    if (nombre == "") {
        document.getElementById("ErrorNombreApunte").innerHTML = "Ingrese Nombre";
        valido = false;
    }
    if (apellido == "") {
        document.getElementById("ErrorEstado").innerHTML = "Ingrese Apellido";
        valido = false;
    }
    if (documento == "") {
        document.getElementById("ErrorDigitalizado").innerHTML = "Ingrese Documento";
        valido = false;
    }
    
    return valido;

}