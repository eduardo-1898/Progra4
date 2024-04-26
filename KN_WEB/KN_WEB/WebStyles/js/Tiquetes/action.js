$("#addMessage").click(function () {

    var formData = new FormData();


    tinyMCE.triggerSave();
    var msj = tinyMCE.activeEditor.getContent({ format: 'text' }); 
    tinyMCE.triggerSave();

    formData.append('msj', msj);
    formData.append('idTiquete', $("#txtTiquete").val());

    $.ajax({
        url: resolveUrl('~/Mensajes/AddMensajeTiquete'),
        data: formData,
        type: 'POST',
        contentType: false,
        processData: false,
        success: function (data) {
            if (data == "OK") {
                $('#mensajeModal').modal('toggle')
                $('#descripcion').val('')
                Swal.fire(
                    'Exito',
                    'Se ha ejecutado el proceso éxitomamente',
                    'success',
                    'timer:5000'
                ).then((dismiss) => {
                    location.reload();
                })

            }
            else {
                $('#mensajeModal').modal('toggle')
                Swal.fire(
                    'Error',
                    'Se ha producido un error al ejecutar el procedimiento solicitado',
                    'error',
                    'timer:5000'
                ).then((dismiss) => {

                })
            }

        }
    })

});