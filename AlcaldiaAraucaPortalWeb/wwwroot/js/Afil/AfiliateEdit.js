const urlServidor = window.location.hostname == "localhost" || window.location.hostname == "127.0.0.1" ? "https://localhost:7292/" : "https://www.araucactiva.com/";

function ProductivoAdd(id) {
    $('#spanGroupProductiveId').text('').show('hide');

    if ($('#groupProductiveId option:selected').val() == "0") {
        $('#spanGroupProductiveId').text('!El campo es requerido¡').show();
        $('#groupProductiveId').focus();
    } else {

        $.ajax({
            type: 'POST',
            url: urlServidor + 'Affiliates/ProductiveAdd',
            data: { id: id, GroupProductiveId: $("#groupProductiveId").val() },
            success: function (data) {

                if (data.data.succeeded == true) {
                    window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
                } else {
                    alert('Falló al agregar grupo productivo. \n' + data.data.message);
                }
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
        success: function (data) {
            if (data.data.succeeded==true) {
                window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
            } else {
                alert('Falló al borrr grupo productivo. \n' + data.data.message);
            }

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
        $.ajax({
            type: 'POST',
            url: urlServidor + 'Affiliates/GroupCommunityAdd',
            data: { id: id, GroupCommunityId: $("#groupCommunityId option:selected").val() },
            success: function (data) {
                if (data.data.succeeded) {
                    window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
                } else {
                    alert('Falló al agregar grupo comunitario. \n' + data.data.message);
                }
            },
            error: function (ex) {
                alert('Falló al agregar grupo comunitario. ' + ex);
            }
        });
    }
}
function CommunityDelete(id, AffiliateGroupCommunityId) {
    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/GroupCommunityDelete',
        data: { GroupCommunityId: AffiliateGroupCommunityId },
        success: function (data) {
            if (data.data.succeeded) {
                window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
            } else {
                alert('Falló al borrar grupo comunitario. \n' + data.data.message);
            }
        },
        error: function (ex) {
            alert('Falló al borrar grupo comunitario.' + ex);
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
    } else if ($('#Concept').val() == "") {
        $('#spanConcept').text('!El campo es requerido¡').show();
        $('#Concept').focus();
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
                if (data.data.succeeded) {
                    window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
                } else {
                    alert('Falló al agregar la profesion. \n' + data.data.message);
                }
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
        success: function (data) {
            if (data.data.succeeded) {
                window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
            } else {
                alert('Falló al borrar la profesion. \n' + data.data.message);
            }
        },
        error: function (ex) {
            alert('Falló al borrar la profesión.' + ex);
        }
    });
}

function SocialNetworkAdd(id) {

    $('#spanSocialNetworkId').text('').show('hide');

    $('#spanAffiliateSocialNetworURL').text('').show('hide');

    if ($('#socialNetworkId option:selected').val() == "0") {
        $('#spanSocialNetworkId').text('!El campo es requerido¡').show();
        $('#socialNetworkId').focus();
    }
    else if ($('#affiliateSocialNetworURL').val() == "") {
        $('#spanAffiliateSocialNetworURL').text('!El campo es requerido¡').show();
        $('#affiliateSocialNetworURL').focus();
    }
    else {
        var formData = new FormData();

        formData.append("id", id);
        formData.append("socialNetworkId", $("#socialNetworkId option:selected").val());
        formData.append("affiliateSocialNetworURL", $("#affiliateSocialNetworURL").val());

        $.ajax({
            type: 'POST',
            url: urlServidor + 'Affiliates/SocialNetworkAdd',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.data.succeeded) {
                    window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
                } else {
                    alert('Falló al agregar la red social. \n' + data.data.message);
                }
            },
            error: function (ex) {
                alert('Falló al agregar la red social. ' + ex);
            }
        });
    }


}
function SocialNetworkDelete(id, AffiliateSocialNetworkId) {

    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/SocialNetworkDelete',
        data: { affiliateSocialNetworkId: AffiliateSocialNetworkId },
        success: function (data) {
            if (data.data.succeeded) {
                window.location.href = urlServidor + "Affiliates/Edit/?id=" + id;
            } else {
                alert('Falló al borrar la red social. \n' + data.data.message);
            }
        },
        error: function (ex) {
            alert('Falló al borrar la red social. ' + ex);
        }
    });

}
