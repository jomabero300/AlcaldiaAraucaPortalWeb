const urlServidor = window.location.hostname == "localhost" || window.location.hostname == "127.0.0.1" ? "https://localhost:7292/" : "https://www.araucactiva.com/";

let numP = 0;
let numD = 0;
let numC = 0;
let numS = 0;

function ProfessionAdd() {
    if (ProfessionDetalleValidate()) {

        var formData = new FormData();

        formData.append("fileImg", $("#profImagePath")[0].files[0]);
        formData.append("fileDoc", $("#profdocumentoPath")[0].files[0]);

        $.ajax({
            type: "POST",
            url: urlServidor + "Affiliates/UploadeTemp",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                $("#myTableProfession tbody").append("<tr>" +
                    "<td>" + $("#professionId option:selected").text() + "</td>" +
                    "<td><img src='" + data.pathImg + "' class='img - rounded' alt='Image' style='width: 100px; height: 100px; max - width: 100 %; height: auto;' /></td>" +
                    "<td>" + $("#profConcept").val() + "</td>" +

                    "<td width='10%'><a href='" + data.pathDoc + "' target='_blank'><i class='bi bi-file-earmark-pdf-fill' style='font-size:30px;'></i></a></td>" +

                    "<td style='display: none;'>" + data.pathImg + "</td>" +
                    "<td style='display: none;'>" + data.pathDoc + "</td>" +
                    "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="ProfessionDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
                    "</tr>");

                $("#divProfession table").append(
                    "<input type='hidden' name='Professions.Index' value=" + numP + " /> " +
                    "<input type='hidden' name='Professions[" + numP + "].ProfessionId' value='" + $("#professionId").val() + "'/> " +
                    "<input type='hidden' name='Professions[" + numP + "].ImagePath' value='" + data.pathImg + "'/> " +
                    "<input type='hidden' name='Professions[" + numP + "].Concept' value='" + $("#profConcept").val() + "'/> " +
                    "<input type='hidden' name='Professions[" + numP + "].DocumentoPath' value='" + data.pathDoc + "'/> "
                );

                $("#professionId").val("0");
                $("#profImagePath").val("");
                $("#profConcept").val("");
                $("#profdocumentoPath").val("");

                numP++;
                //Profession();
            },
            error: function (ex) {
                alert('Failed to retrieve.' + ex);
            }
        });
    }
}
function ProfessionDelete(ctl) {
    _row = $(ctl).parents("tr");

    var cols = _row.children("td");

    var pathImg = $(cols[4]).text();
    var pathPdf = $(cols[5]).text();
    $.ajax({
        type: "POST",
        url: urlServidor + "Affiliates/DeleteTemp",
        data: { fileImg: pathImg, filePdf: pathPdf },
        success: function (data) {

            var count = $("#myTableProfession tr").length - 1;

            var index = $(ctl).closest("tr").index();

            $(ctl).parents("tr").remove();

            $("input[value='" + index + "']").remove();

            $("input[name='Professions[" + index + "].ProfessionId']").remove();
            $("input[name='Professions[" + index + "].ImagePath']").remove();
            $("input[name='Professions[" + index + "].Concept']").remove();
            $("input[name='Professions[" + index + "].DocumentoPath']").remove();

            numP--;
            //Profession();
        },

        error: function (ex) {
            alert('Failed to retrieve cities.' + ex);
        }
    });

}
function ProfessionDetalleValidate() {
    var isValid = true;

    $('#spanProfessionId').text('').show('hide');
    $('#spanProfImagePath').text('').show('hide');
    $('#spamProfConcept').text('').show('hide');
    $('#spanProfDocumentoPath').text('').show('hide');

    if ($('#professionId option:selected').val() == "0") {

        $('#spanProfessionId').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#professionId').focus();
        }

        isValid = false;
    }

    if ($('#profImagePath').val().trim() == "") {

        $('#spanProfImagePath').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#profImagePath').focus();
        }

        isValid = false;
    }

    if ($('#profConcept').val().trim() == "") {

        $('#spamProfConcept').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#profConcept').focus();
        }

        isValid = false;
    }

    if ($('#profdocumentoPath').val().trim() == "") {

        $('#spanProfDocumentoPath').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#profdocumentoPath').focus();
        }

        isValid = false;
    }

    return isValid;
}
function btnProfessionAdd(valor) {

    if (valor > 1) {
        document.getElementById('btnProfession').disabled = true;
    } else {
        document.getElementById('btnProfession').disabled = false;
    }
}
function Profession() {
    var tableProductive = document.getElementById('myTableProfession');
    let ltCade = "";
    for (var i = 1, row; row = tableProductive.rows[i]; i++) {
        col = row.cells[0];
        ltCade = ltCade + col.innerHTML + ",";
    }

    $("#professionId").empty();
    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/getProfession/',
        dataType: 'json',
        data: { GroupProfession: ltCade },
        success: function (data) {
            $.each(data, function (i, data) {
                $("#professionId").append('<option value="'
                    + data.professionId + '">'
                    + data.professionName + '</option>');
            });
        },
        error: function (ex) {
            alert('Failed to retrieve prossions.' + ex);
        }
    });
}

function ProductivoAdd() {
    if (ProductivoValidate()) {
        $("#myTableProductive tbody").append("<tr>" +
            "<td>" + $("#groupProductiveId option:selected").text() + "</td>" +
            "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="ProductiveDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
            "</tr>");

        $("#divProductive table").append(
            "<input type='hidden' name='Productivo.Index' value=" + numD + " /> " +
            "<input type='hidden' name='Productivo[" + numD + "].GroupProductiveId' value='" + $("#groupProductiveId").val() + "'/> "
        );

        $("#groupProductiveId").val(0)
        numD++;
        btnProdutiveAdd(numD);
        Productivo();
    }
}
function ProductiveDelete(ctl) {

    _row = $(ctl).parents("tr");

    var cols = _row.children("td");

    var count = $("#myTableProductive tr").length - 1;

    var index = $(ctl).closest("tr").index();

    $(ctl).parents("tr").remove();

    $("input[value='" + index + "']").remove();

    $("input[name='Productivo[" + index + "].GroupProductiveId']").remove();

    document.getElementById('btnAddPropductive').disabled = false;
    numD--;

    Productivo();
}
function btnProdutiveAdd(valor) {

    if (valor > 1) {
        document.getElementById('btnAddPropductive').disabled = true;
    } else {
        document.getElementById('btnAddPropductive').disabled = false;
    }
}
function Productivo() {
    var tableProductive = document.getElementById('myTableProductive');
    let ltCade = "";
    for (var i = 1, row; row = tableProductive.rows[i]; i++) {
        col = row.cells[0];
        ltCade = ltCade + col.innerHTML + ",";
    }

    $("#groupProductiveId").empty();
    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/getProductive/',
        dataType: 'json',
        data: { GroupProductive: ltCade },
        success: function (data) {
            $.each(data, function (i, data) {
                $("#groupProductiveId").append('<option value="'
                    + data.groupProductiveId + '">'
                    + data.groupProductiveName + '</option>');
            });
        },
        error: function (ex) {
            alert('Failed to retrieve cities.' + ex);
        }
    });
}
function ProductivoValidate() {
    var isValid = true;
    $('#spangroupProductiveId').text('').show('hide');

    if ($('#groupProductiveId option:selected').val() == "0") {

        $('#spangroupProductiveId').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#groupProductiveId').focus();
        }

        isValid = false;
    }

    return isValid;
}

function CommunityAdd() {
    if (CommunityValidate()) {
        $("#myTableGroupCommunity tbody").append("<tr>" +
            "<td>" + $("#groupCommunityId option:selected").text() + "</td>" +
            "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="CommunityDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
            "</tr>");

        $("#divGroupCommunity table").append(
            "<input type='hidden' name='Comuntario.Index' value=" + numC + " /> " +
            "<input type='hidden' name='Comuntario[" + numC + "].GroupCommunityId' value='" + $("#groupCommunityId").val() + "'/> "
        );

        $("#groupCommunityId").val(0)
        numC++;
        btnCommunityDisable(numC);
        Community();
    }
}
function CommunityDelete(ctl) {

    _row = $(ctl).parents("tr");

    var cols = _row.children("td");

    var count = $("#myTableGroupCommunity tr").length - 1;

    var index = $(ctl).closest("tr").index();

    $(ctl).parents("tr").remove();

    $("input[value='" + index + "']").remove();

    $("input[name='Comuntario[" + index + "].GroupCommunityId']").remove();

    document.getElementById('btnGroupCommunity').disabled = false;
    numC--;

    Community();
}
function btnCommunityDisable(valor) {

    if (valor > 1) {
        document.getElementById('btnGroupCommunity').disabled = true;
    } else {
        document.getElementById('btnGroupCommunity').disabled = false;
    }
}
function Community() {
    var myTable = document.getElementById('myTableGroupCommunity');
    let ltCade = "";
    for (var i = 1, row; row = myTable.rows[i]; i++) {
        col = row.cells[0];
        ltCade = ltCade + col.innerHTML + ",";
    }

    $("#groupCommunityId").empty();
    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/getCommunity/',
        dataType: 'json',
        data: { GroupCommunity: ltCade },
        success: function (data) {
            $.each(data, function (i, data) {
                $("#groupCommunityId").append('<option value="'
                    + data.groupCommunityId + '">'
                    + data.groupCommunityName + '</option>');
            });
        },
        error: function (ex) {
            alert('Failed to retrieve cities.' + ex);
        }
    });

}
function CommunityValidate() {
    var isValid = true;
    $('#spanGroupCommunityId').text('').show('hide');

    if ($('#groupCommunityId option:selected').val() == "0") {

        $('#spanGroupCommunityId').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#groupCommunityId').focus();
        }

        isValid = false;
    }

    return isValid;
}

function SocialNetworkAdd() {
    if (SocialNetworkValidate()) {
        const redNetwors = "facebook twitter instagram youtube tiktok linkedin whatsapp";

        let redNetwor = $("#socialNetworkId option:selected").text().toLowerCase();

        if (!redNetwors.includes(redNetwor)) {
            redNetwor = "link";
        }

        

        console.log(redNetwor);

        $("#myTableSocialNetwork tbody").append("<tr>" +
            "<td>" + $("#socialNetworkId option:selected").text() + "</td>" +

            "<td width='10%'><a href='" + $("#socialNetworURL").val() + "' target='_blank'><i class='bi bi-" + redNetwor +"' style='font-size:30px;'></i></a></td>" +

            "<td>" + '<button class="btn btn-sm btn-danger" type="button" onclick="SocialNetworkDelete(this)"><i class="bi bi-trash2"></i></button>' + "</td>" +
            "</tr>");

        $("#divSocialNetwork table").append(
            "<input type='hidden' name='SocialNetwork.Index' value=" + numS + " /> " +
            "<input type='hidden' name='SocialNetwork[" + numS + "].SocialNetworkId' value='" + $("#socialNetworkId").val() + "'/> " +
            "<input type='hidden' name='SocialNetwork[" + numS + "].SocialNetworURL' value='" + $("#socialNetworURL").val() + "'/> "
        );

        $("#socialNetworkId").val(0);
        $("#socialNetworURL").val("");
        numS++;
        btnSocialNetworkDisable(numS);
        SocialNetwork();
    }
}
function SocialNetworkDelete(ctl) {

    _row = $(ctl).parents("tr");

    var cols = _row.children("td");

    var count = $("#myTableSocialNetwork tr").length - 1;

    var index = $(ctl).closest("tr").index();

    $(ctl).parents("tr").remove();

    $("input[value='" + index + "']").remove();

    $("input[name='SocialNetwork[" + index + "].SocialNetworkId']").remove();

    $("input[name='SocialNetwork[" + index + "].SocialNetworURL']").remove();

    document.getElementById('btnAddSocialNetwork').disabled = false;

    numS--;

    SocialNetwork();
}
function btnSocialNetworkDisable(valor) {

    if (valor > 1) {
        document.getElementById('btnAddSocialNetwork').disabled = true;
    } else {
        document.getElementById('btnAddSocialNetwork').disabled = false;
    }
}
function SocialNetwork() {
    var myTable = document.getElementById('myTableSocialNetwork');

    let ltCade = "";

    for (var i = 1, row; row = myTable.rows[i]; i++) {
        col = row.cells[0];
        ltCade = ltCade + col.innerHTML + ",";
    }

    $("#socialNetworkId").empty();
    $.ajax({
        type: 'POST',
        url: urlServidor + 'Affiliates/getSocialNetwork/',
        dataType: 'json',
        data: { SocialNetwork: ltCade },
        success: function (data) {
            $.each(data, function (i, data) {
                $("#socialNetworkId").append('<option value="'
                    + data.socialNetworkId + '">'
                    + data.socialNetworkName + '</option>');
            });
        },
        error: function (ex) {
            alert('Failed to retrieve cities.' + ex);
        }
    });

}
function SocialNetworkValidate() {
    var isValid = true;
    $('#spanSocialNetworkId').text('').show('hide');

    if ($('#socialNetworkId option:selected').val() == "0") {

        $('#spanSocialNetworkId').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#socialNetworkId').focus();
        }

        isValid = false;
    }

    return isValid;
}