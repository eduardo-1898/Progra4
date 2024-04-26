var tiquetes = (function () {
    $(document).ready(function () {
        var table = $('#tableClosed').DataTable({
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
            "ajax": resolveUrl("~/Ticket/ListClosed"),
            "columns": [
                {
                    "orderable": true,
                    "data": "IdTiquete",
                    "title": "ID Ticket",
                    "render": function (data, type, row, meta) {
                        return data;
                    }
                },
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
                    "data": "FechaInicio",
                    "title": "Fecha de creación",
                    "render": function (data, type, row, meta) {
                        var num = parseInt(data.replace(/[^0-9]/g, ""));
                        var date = new Date(num);
                        return date.toLocaleString('es-ES').split(',')[0];
                    }
                },
                {
                    "orderable": true,
                    "data": "FechaFinal",
                    "title": "Fecha de finalización",
                    "render": function (data, type, row, meta) {
                        var num = parseInt(data.replace(/[^0-9]/g, ""));
                        var date = new Date(num);
                        return date.toLocaleString('es-ES').split(',')[0];
                    }
                },
                {
                    "orderable": false,
                    "data": "IdTiquete",
                    "width": "14%",
                    "render": function (data, type, row, meta) {
                        return getButtons(data, row);
                    }
                }
            ],
            "order": [[0, 'des']],
            //Bfrtip
            dom: '<"dt-top-container"<l><"dt-center-in-div"B><f>r>t<ip>',
        });
    });

    var getButtons = function (data, row) {
        html = "<a title='Ver' class='btn btn-sm btn-primary' margin-right: 5px;' href='" + resolveUrl("~/Ticket/Edit?id=" + row.IdTiquete) + "''><i class='fas fa-eye'></i></a>";
        return html;
    }

}());
