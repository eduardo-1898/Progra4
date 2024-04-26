document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("sendform").addEventListener('submit', validarFormulario);
});

function validarFormulario(evento) {
    evento.preventDefault();
    var email = $("#email").val();
    var pass1 = $("#firstPassword").val();
    var pass2 = $("#secondPassword").val();

    if (pass1 != pass2) {

        Swal.fire({
            icon: 'info',
            title: 'Upss, parece que algo no anda bien..',
            text: 'Las contraseñas ingresadas no coinciden'
        })

    }
    else if (email != null || email != "") {
        Swal.fire({
            icon: 'error',
            title: 'Ha ocurrido un error..',
            text: 'No se ha podido cargar la solicitud de cambio de contraseña correctamente'
        })
    }
    else {
        this.submit();
    };
};