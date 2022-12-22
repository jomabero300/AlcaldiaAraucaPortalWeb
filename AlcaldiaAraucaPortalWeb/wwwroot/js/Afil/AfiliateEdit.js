const urlServidor = window.location.hostname == "localhost" || window.location.hostname == "127.0.0.1" ? "https://localhost:7292/" : "https://www.araucactiva.com/";

function ProductivoAdd(id) {
    $('#spanGroupProductiveId').text('').show('hide');

    if ($('#groupProductiveId option:selected').val() == "0") {
        console.log("Debe seleccionar");
        $('#spanGroupProductiveId').text('!El campo es requerido¡').show();
        $('#groupProductiveId').focus();
    } else {
        console.log("Ejecutando el proceso");
        $.ajax({
            type: 'POST',
            url: urlServidor + 'Affiliates/ProductiveAdd',
            data: { id: id, GroupProductiveId: $("#groupProductiveId").val() },
            success: function (res) {
                window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
            },
            error: function (ex) {
                alert('Falló al agregar grupo productivo. ' + ex);
            }
        });
    }
}
function ProductivoDelete(id, GroupProductiveId) {
    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/ProductiveDelete',
        data: { GroupProductiveId: GroupProductiveId },
        success: function (res) {
            window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
        },
        error: function (ex) {
            alert('Falló al borrar grupo productivo.' + ex);
        }
    });

}

function CommunityAdd(id) {

    $('#spanGroupCommunityId').text('').show('hide');
    if ($('#groupCommunityId option:selected').val() == "0") {
        $('#spanGroupCommunityId').text('!El campo es requerido¡').show();
        $('#groupCommunityId').focus();
    } else {
        console.log("Ejecutando el proceso");
        $.ajax({
            type: 'POST',
            url: urlServidor + 'Affiliates/GroupCommunityAdd',
            data: { id: id, GroupCommunityId: $("#groupCommunityId").val() },
            success: function (res) {
                window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
            },
            error: function (ex) {
                alert('Falló al agregar grupo productivo. ' + ex);
            }
        });
    }
}
function CommunityDelete(id, AffiliateGroupCommunityId) {
    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/GroupCommunityDelete',
        data: { GroupCommunityId: AffiliateGroupCommunityId },
        success: function (res) {
            window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
        },
        error: function (ex) {
            alert('Falló al borrar grupo comunitaio.' + ex);
        }
    });

}

function ProfessionAdd(id) {

    $('#spanProfessionId').text('').show('hide');
    $('#spanImagePath').text('').show('hide');
    $('#spanConcept').text('').show('hide');
    $('#spanDocumentoPath').text('').show('hide');

    if ($('#professionId option:selected').val() == "0") {
        $('#spanProfessionId').text('!El campo es requerido¡').show();
        $('#professionId').focus();

    } else if ($('#imagePath').val() == "") {
        $('#spanImagePath').text('!El campo es requerido¡').show();
        $('#imagePath').focus();

    } else if ($('#Concept').val() == "") {
        $('#spanConcept').text('!El campo es requerido¡').show();
        $('#Concept').focus();

    } else if ($('#documentoPath').val() == "") {
        $('#spanDocumentoPath').text('!El campo es requerido¡').show();
        $('#documentoPath').focus();
    } else {

        var formData = new FormData();

        formData.append("id", id);
        formData.append("ProfessionId", $("#professionId").val());
        formData.append("ImagePath", $("#imagePath")[0].files[0]);
        formData.append("Concept", $("#Concept").val());
        formData.append("DocumentoPath", $("#documentoPath")[0].files[0]);

        $.ajax({
            type: 'POST',
            url: urlServidor + 'Affiliates/ProfessionAdd',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
            },
            error: function (ex) {
                alert('Falló al agregar la profesion. ' + ex);
            }
        });

    }
}
function ProfessionsDelete(id, AffiliateProfessionId) {

    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/ProfessionDelete',
        data: { ProfessionId: AffiliateProfessionId },
        success: function (res) {
            window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
        },
        error: function (ex) {
            alert('Falló al borrar la profesión.' + ex);
        }
    });
}

