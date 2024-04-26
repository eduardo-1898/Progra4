document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("sendform").addEventListener('submit', validarFormulario);
});

function validarFormulario(evento) {
    evento.preventDefault();
    var email = $("#email").val();

    if (email.length < 6) {

        Swal.fire({
            icon: 'info',
            title: 'Ha ocurrido un error..',
            text: 'El correo no parece contener un formato valido, favor revisar el formato ingresado'
        })
    }
    else {
        this.submit();
    };
};