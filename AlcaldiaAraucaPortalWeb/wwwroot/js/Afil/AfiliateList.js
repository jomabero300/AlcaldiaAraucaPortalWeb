const urlServidor = window.location.hostname == "localhost" || window.location.hostname == "127.0.0.1" ? "https://localhost:7292/" : "https://www.araucactiva.com/";

$(document).ready(function () {
    $('#MyTable').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": urlServidor + "Professions/ListProfesiona",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "professionName" },
            {
                "data": "professionId", "render": function (data) {
                    return '<a href="/Professions/Edit/' + data + '" class="btn btn-sm btn-warning"><i class="bi bi-pencil-fill" title="Editar"></i> Editar</a> |' +
                        '<a href="/Professions/Details/' + data + '" class="btn btn-sm btn-info"><i class="bi bi-eye-fill" title="Datlles"></i> Detalle</a> |' +
                        '<a href="/Professions/Delete/' + data + '" class="btn btn-sm btn-danger"><i class="bi bi-trash2-fill" title="Borrar"></i> Borrar</a> '

                }
            }
        ]
    });

    $('#MyTableGroupComunity').DataTable({
        "paging": true,
        "searching": true,
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "processing": true,
        "serverSide": true,
        "order": "[[0, 'desc']]",
        "ajax": {
            "url": urlServidor + "GroupCommunities/ListGene",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "groupCommunityName" },
            { "data": "state", "render": function(data) { return data.stateName } },
            {
                "data": "groupCommunityId", "render": function (data) {
                    return '<a href="/GroupCommunities/Edit/' + data + '" class="btn btn-sm btn-warning"><i class="bi bi-pencil-fill" title="Editar"></i> Editar</a> ' +
                        '<a href="/GroupCommunities/Details/' + data + '" class="btn btn-sm btn-info"><i class="bi bi-eye-fill" title="Datlles"></i> Detalle</a> ' +
                        '<a href="/GroupCommunities/Delete/' + data + '" class="btn btn-sm btn-danger"><i class="bi bi-trash2-fill" title="Borrar"></i> Borrar</a> '

                }
            }
        ]
    });

    $('#MyTableGroupProductive').DataTable({
        "paging": true,
        "searching": true,
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "processing": true,
        "serverSide": true,
        "order": "[[0, 'desc']]",
        "ajax": {
            "url": urlServidor + "GroupProductives/ListGene",
            "type": "POST",
            "datatype": "json",
        },
        "columns": [
            { "data": "groupProductiveName" },
            { "data": "state", "render": function(data) { return data.stateName } },
            {
                "data": "groupCommunityId", "render": function (data) {
                    return '<a href="/GroupProductives/Edit/' + data + '" class="btn btn-sm btn-warning"><i class="bi bi-pencil-fill" title="Editar"></i> Editar</a> |' +
                        '<a href="/GroupProductives/Details/' + data + '" class="btn btn-sm btn-info"><i class="bi bi-eye-fill" title="Datlles"></i> Detalle</a> |' +
                        '<a href="/GroupProductives/Delete/' + data + '" class="btn btn-sm btn-danger"><i class="bi bi-trash2-fill" title="Borrar"></i> Borrar</a> '

                }
            }
        ]
    });

    $('#MyTableSocialNetwork').DataTable({
        "paging": true,
        "searching": true,
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": urlServidor + "SocialNetworks/ListGene",
            "type": "POST",
            "datatype": "json",
        },
        "columns": [
            { "data": "socialNetworkName" },
            { "data": "state", "render": function(data) { return data.stateName } },
            {
                "data": "socialNetworkId", "render": function (data) {
                    return '<a href="/SocialNetworks/Edit/' + data + '" class="btn btn-sm btn-warning"><i class="bi bi-pencil-fill" title="Editar"></i> Editar</a> |' +
                        '<a href="/SocialNetworks/Details/' + data + '" class="btn btn-sm btn-info"><i class="bi bi-eye-fill" title="Datlles"></i> Detalle</a> |' +
                        '<a href="/SocialNetworks/Delete/' + data + '" class="btn btn-sm btn-danger"><i class="bi bi-trash2-fill" title="Borrar"></i> Borrar</a> '

                }
            }
        ]
    });

    $('#MyTablePrensa').DataTable({
        "paging": true,
        "searching": true,
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": urlServidor + "Prensas/ListGene",
            "type": "POST",
            "datatype": "json",
        },
        "columns": [
            { "data": "contentDate" },
            { "data": "contentTitle" },
            { "data": "contentText" },
            {
                "data": "contentUrlImg", "render": function (data) {
                    return '<img src=' + data + ' class="img-rounded" alt="Image" style="width:60px;height:60px;max-width: 60%; height: auto;" />'
                }
            },
            { "data": "state", "render": function(data) { return data.stateName } },
            {
                "data": "contentId", "render": function (data) {


                    return '<a href="/Prensas/Edit/' + data + '" class="btn btn-sm btn-warning"><i class="bi bi-pencil-fill" title="Editar"></i> Editar</a> ' +
                              '<a href="/Prensas/Delete/' + data + '" class="btn btn-sm btn-danger"><i class="bi bi-trash2-fill" title="Borrar"></i> Borrar</a> '
                }
            }
        ]
    });

});/*https://www.youtube.com/watch?v=1ni6bId8gcw*/