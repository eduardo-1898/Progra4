var usuarios = (function () {

    $(document).ready(function () {
        var table = $('#usuariosTable').DataTable({
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
            "ajax": resolveUrl("~/Usuarios/List"),
            "columns": [
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
                    "data": "Apellido1",
                    "title": "Apellido 1",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Apellido2",
                    "title": "Apellido 2",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "Correo",
                    "title": "Correo electrónico",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": true,
                    "data": "NombreRol",
                    "title": "Rol",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
                {
                    "orderable": false,
                    "data": "IdUsuario",
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
        html = "<a title='Editar' class='btn btn-sm btn-primary' margin-right: 5px;' onclick='usuarios.Edit(" + '"' + row.IdUsuario + '"' + ")'><i class='fas fa-pencil-alt'></i></a>";
        return html;
    }


    function Edit(id) {
        var formData = new FormData();
        formData.append('id', id);
        $.ajax({
            url: resolveUrl("~/Usuarios/GetUserById"),
            data: formData,
            type: 'POST',
            contentType: false,
            processData: false,
            success: function (data) {
                $("#IdUsuario").val(data.IdUsuario);
                $("#Nombre").val(data.Nombre);
                $("#Apellido1").val(data.Apellido1);
                $("#Apellido2").val(data.Apellido2);
                $("#Correo").val(data.Correo);
                $("#idRol").val(data.IdRol);

                var table = $('#usuariosTable').DataTable();
                table.search();
                table.ajax.reload();
            }
        });
    }

    return {
        Edit: Edit
    };

}());
