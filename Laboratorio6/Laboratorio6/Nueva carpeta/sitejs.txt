function limpiarCampos() {
    document.getElementById("nombre").value = "";
    document.getElementById("apellidos").value = "";
    document.querySelector('input[name="sexo"]:checked').checked = false;
    document.getElementById("correo").value = "";
    document.getElementById("direccion").value = "";
    document.getElementById("ciudadDropdown").value = "";
    document.getElementById("descripcion").value = "";
}

function validarInformacion() {
    // Lógica de validación del formulario
    var nombre = document.getElementById("nombre").value;
    var apellidos = document.getElementById("apellidos").value;
    var sexo = document.querySelector('input[name="sexo"]:checked');
    var correo = document.getElementById("correo").value;
    var direccion = document.getElementById("direccion").value;
    var ciudad = document.getElementById("ciudadDropdown").value;
    var descripcion = document.getElementById("descripcion").value;

    // Aquí puedes agregar cualquier validación adicional que necesites
    console.log("HOlasas")
    if (nombre === "" || apellidos === "" || sexo === null || correo === "" || direccion === "" || ciudad === "" || descripcion === "") {
        // Mostrar mensaje de error
        $('#myModal .modal-body').html("Por favor, complete todos los campos.");
        $('#myModal').modal('show');
        return false;
    }

    return true;
}
