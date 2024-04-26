var servicio = (function () {

    $(document).ready(function () {
        var table = $('#serviceTable').DataTable({
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
            "ajax": resolveUrl("~/Servicios/List"),
            "columns": [
                {
                    "orderable": true,
                    "data": "TipoServicio",
                    "title": "Tipo de servicio",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Tiempo",
                    "title": "Tiempo",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": false,
                    "data": "idServicio",
                    "width": "14%",
                    "render": function (data, type, row, meta) {
                        return getButtons(data, row);
                    }
                }
            ],
            "order": [[0, 'des']],
            dom: 'Bfrtip',
        });
    });

    var getButtons = function (data, row) {
        html = "<a title='Editar' class='btn btn-sm btn-primary' margin-right: 5px;' onclick='servicio.Edit(" + '"' + row.idServicio + '"' + ")'><i class='fas fa-pencil-alt'></i></a>";
        return html;
    }


    function Edit(id) {
        var formData = new FormData();
        formData.append('id', id);
        $.ajax({
            url: resolveUrl("~/Servicios/GetServicioById"),
            data: formData,
            type: 'POST',
            contentType: false,
            processData: false,
            success: function (data) {
                $("#idServicio").val(data.idServicio);
                $("#TipoServicio").val(data.TipoServicio);
                $("#tiempo").val(data.Tiempo);

                var table = $('#serviceTable').DataTable();
                table.search();
                table.ajax.reload();

            }
        });
    }

    return {
        Edit: Edit
    };

}());
