$(document).ready(function () {
    $('#MyTable').DataTable({
        paging: true,
        searching: true,
        language: {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        order: [[0, 'desc']],
        "aLengthMenu": [
            [25, 50, 100, 200, -1],
            [25, 50, 100, 200, "Todos"]
        ]
    });
    $('#MyTableGene').DataTable({
        paging: true,
        searching: true,
        language: {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
        },
        order: [[0, 'asc']],
        "aLengthMenu": [
            [25, 50, 100, 200, -1],
            [25, 50, 100, 200, "Todos"]
        ]
    });
});
