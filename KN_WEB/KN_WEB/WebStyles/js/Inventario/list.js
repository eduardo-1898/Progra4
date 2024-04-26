var inventario = (function () {

    $(document).ready(function () {
        var table = $('#inventoryTable').DataTable({
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
            "ajax": resolveUrl("~/Inventario/List"),
            "columns": [
                {
                    "orderable": true,
                    "data": "TipoEquipo",
                    "title": "Tipo de equipo",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Marca",
                    "title": "Marca",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Modelo",
                    "title": "Modelo",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Serie",
                    "title": "Serie",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Nombre",
                    "title": "Nombre",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "VersionInv",
                    "title": "Versión",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": false,
                    "data": "IdInventario",
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
        html = "<a title='Editar' class='btn btn-sm btn-primary' margin-right: 5px;' onclick='inventario.Edit(" + '"' + row.IdInventario + '"' + ")'><i class='fas fa-pencil-alt'></i></a>";
        return html;
    }


    function Edit(id) {
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

                var table = $('#inventoryTable').DataTable();
                table.search();
                table.ajax.reload();
            }
        });
    }

    return {
        Edit: Edit
    };

}());
