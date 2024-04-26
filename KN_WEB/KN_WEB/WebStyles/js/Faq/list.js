var Faqq = (function () {

    $(document).ready(function () {
        var table = $('#FaqqTable').DataTable({
            "pageLength": 5,
            "processing": true,
            "serverSide": false,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
            },
            lengthChange: false,
            buttons:
                [
                ],
            "ajax": {
                "url": resolveUrl("~/Faqq/ListFaqq"),
                "type": "GET",
                "dataType": "json",
                "cache": false,
                "dataSrc": "data", // Especifica el nombre del campo que contiene los datos en la respuesta JSON
                "error": function (xhr, error, thrown) {
                    console.log("Error en la solicitud AJAX:", xhr, error, thrown);
                    alert("Error en la solicitud AJAX:", xhr, error, thrown)
                }
            },
            "columns": [
                {
                    "orderable": true,
                    "data": "Titulo",
                    "title": "Título",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Descripcion",
                    "title": "Descripción",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Solucion",
                    "title": "Solución",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                }
            ],
            "order": [[0, 'des']],
            dom: 'Bfrtip',
        });
    });

    var getButtons = function (data, row) {
        html = "<a title='Editar' class='btn btn-sm btn-primary' margin-right: 5px;' onclick='inventario.Edit(" + '"' + row.IdInventario + '"' + ")'><i class='fas fa-pencil-alt'></i></a>";
        return html;
    }


    /*function Edit(id) {
        var formData = new FormData();
        formData.append('id', id);
        $.ajax({
            url: resolveUrl("~/Inventario/GetInventaryById"),
            data: formData,
            type: 'POST',
            contentType: false,
            processData: false,
            success: function (data) {
                $("#idInventario").val(id);
                $("#TipoEquipo").val(data.TipoEquipo);
                $("#marca").val(data.Marca);
                $("#modelo").val(data.Modelo);
                $("#serie").val(data.Serie);
                $("#nombre").val(data.Nombre);
                $("#version").val(data.VersionInv);
            }
        });
    }

    return {
        Edit: Edit
    };*/

}());
