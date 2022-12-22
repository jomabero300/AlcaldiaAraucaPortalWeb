const urlServidor = window.location.hostname == "localhost" || window.location.hostname == "127.0.0.1" ? "https://localhost:7292/" : "https://www.araucactiva.com/";
let numD = 0;
let activeId = 0;

function AddContentDetalle() {

    if (ContentDetalleValidate()) {

        if ($("#OptionFile").val() == "1") {

            if (typeof $("#contentUrlImg")[0].files[0] != "undefined") {
                let formData = new FormData();

                formData.append("file", $("#contentUrlImg")[0].files[0]);

                $.ajax({
                    type: "POST",
                    url: urlServidor + "Contents/UploadeTemp",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        if ($("#btnAddContentDetalle").text() == "Agregar") {
                            ContentDetailBuildTableRow(numD, data.path);
                            numD++;
                        } else {
                            ContentDetailUpdateInTable(activeId, data.path);
                        }
                    },
                    error: function (ex) {
                        alert('Failed to retrieve.' + ex);
                    }
                });
            } else {
                if ($("#btnAddContentDetalle").text() == "Agregar") {
                    ContentDetailBuildTableRow(numD, $("#optionFile").text());
                    numD++;
                } else {
                    ContentDetailUpdateInTable(activeId, $("#optionFile").text());
                }
            }

        } else {
            let imgPath = $("#optionFile").text();

            if ($("#OptionFile").val() == "2") {
                let URL = $("#contentUrlImg").val().trim();

                imgPath = URL == "" ? $("#optionFile").text() : URL;

            }

            if ($("#btnAddContentDetalle").text() == "Agregar") {
                ContentDetailBuildTableRow(numD, imgPath);
                numD++;
            } else {
                ContentDetailUpdateInTable(activeId, imgPath);
            }

        }
    }
}
function ContentDetailDelete(ctl) {

    _row = $(ctl).parents("tr");

    let cols = _row.children("td");

    let path = $(cols[3]).text();

    //TODO: validar que isEsta=1 y ejecuta el ajax

    if (path.indexOf("ImageTemp/") > -1) {
        $.ajax({
            type: "POST",
            url: urlServidor + "Contents/DeleteTemp",
            data: { file: path },
            success: function (data) {
                myTableContentDetalleDelete(ctl);
            },

            error: function (ex) {
                alert('Failed to retrieve cities.' + ex);
            }
        });
    } else {
        myTableContentDetalleDelete(ctl);
    }

}
function ContentDetalleValidate() {
    var isValid = true;

    $('#spanContentTitle').text('').show('hide');
    $('#spanContentText').text('').show('hide');
    $('#spanContentUrlImg').text('').show('hide');
    $('#spanOptionFile').text('').show('hide');

    if ($('#contentTitle').val().trim() == "") {

        $('#spanContentTitle').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentTitle').focus();
        }

        isValid = false;
    }

    if ($('#contentText').val().trim() == "") {

        $('#spanContentText').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentText').focus();
        }

        isValid = false;
    }

    if ($("#btnAddContentDetalle").text() == "Agregar") {
        if ($("#OptionFile").val() == "") {
            $('#spanOptionFile').text('!Debe seleccionar una opcion¡').show();
            $("#OptionFile").focus();
        }
        else if ($("#OptionFile").val() == null) {
            $('#spanOptionFile').text('!El campo es requerido¡').show();

            if (isValid) {
                $('#OptionFile').focus();
            }

            isValid = false;
        } else if ($('#contentUrlImg').val().trim() == "") {

            $('#spanContentUrlImg').text('!El campo es requerido¡').show();

            if (isValid) {
                $('#contentUrlImg').focus();
            }

            isValid = false;
        }
    }


    return isValid;
}

function AddContentEditDetalle(ContentId, isEsta) {

    $("body").css("cursor", "wait");
    
    if (ContentEditDetalleValidate()) {

        let formData = new FormData();

        if ($("#contentDetailsId").text() == "") {

            formData.append("id", ContentId);

            formData.append("Title", $("#contentTitle").val());

            formData.append("ContentText", $("#contentText").val());

            if ($("#OptionFile").val() == "1") {
                formData.append("file", $("#contentUrlImg")[0].files[0]);
            }

            formData.append("fileUrl", $("#contentUrlImg").val());
            
            let ctr = isEsta == '0' ? "Contents" : "Prensas";            

            $.ajax({
                type: "POST",
                url: urlServidor + ctr + "/AddContentDetalle ",
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    $("body").css("cursor", "default");

                    if (response.status == true) {
                        window.location.href = "/" + ctr + "/Edit/" + ContentId
                    }
                }
            });

        } else {

            formData.append("id", ContentId);

            formData.append("Title", $("#contentTitle").val());

            formData.append("ContentText", $("#contentText").val());

            if ($("#OptionFile").val() == "1") {
                formData.append("file", $("#contentUrlImg")[0].files[0]);
            }

            if (typeof $("#contentUrlImg").val() == "undefined" || $("#contentUrlImg").val() == "") {
                formData.append("fileUrl", "");
            } else {
                formData.append("fileUrl", $("#contentUrlImg").val());
            }

            formData.append("idDetail", $("#contentDetailsId").text());

            formData.append("UrlImgOld", $("#optionFile").text());

            formData.append("ContentDetailDate", $("#contentDate").text());

            let ctr = isEsta == '0' ? "Contents" : "Prensas";
            console.log(urlServidor + ctr + "/UpdateContentDetalle");
            $.ajax({
                type: "POST",
                url: urlServidor + ctr + "/UpdateContentDetalle",
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    if (response.status == true) {
                        window.location.href = "/" + ctr + "/Edit/" + ContentId
                    }
                }
            });
        }
    }
}
function ContentEditDetailDelete(ContentDetailsId, ContentId, isEsta) {
    let ctl = isEsta == "0" ? "Contents" : "Prensa"
    let urlDelete = urlServidor + ctl + "/DeleteDetails";

    $.ajax({
        type: "POST",
        url: urlDelete,
        data: { id: ContentDetailsId },
        success: function (response) {

            if (response.status == true) {
                window.location.href = "/" + ctl + "/Edit/?id=" + ContentId
            }
        },
        error: function (ex) {
            alert('Failed to retrieve cities.' + response.message);
        }
    });
}
function ContentEditDetalleValidate() {
    var isValid = true;

    $('#spanContentTitle').text('').show('hide');
    $('#spanContentText').text('').show('hide');
    $('#contentUrlImg').text('').show('hide');

    if ($('#contentTitle').val().trim() == "") {

        $('#spanContentTitle').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentTitle').focus();
        }

        isValid = false;
    }

    if ($('#contentText').val().trim() == "") {

        $('#spanContentText').text('!El campo es requerido¡').show();

        if (isValid) {
            $('#contentText').focus();
        }

        isValid = false;
    }

    if ($("#contentDetailsId").text() == "") {
        if ($("#OptionFile").val() == null) {
            $('#spanOptionFile').text('!El campo es requerido¡').show();

            if (isValid) {
                $('#OptionFile').focus();
            }

            isValid = false;
        } else if ($('#contentUrlImg').val().trim() == "") {

            $('#spanContentUrlImg').text('!El campo es requerido¡').show();

            if (isValid) {
                $('#contentUrlImg').focus();
            }

            isValid = false;
        }
    }

    return isValid;
}

function ContentDetailEdit(ctl) {

    let _row = $(ctl).parents("tr");

    let cols = _row.children("td");

    activeId = $($(cols[6]).children("button")[0]).data("id");

    $("#contentTitle").val($(cols[0]).text());

    $("#contentText").val($(cols[1]).text());

    //$("#optionFile").text($(cols[2]).find('img').attr('src'));

    $("#optionFile").text($(cols[3]).text());

    //console.log($(cols[3]).text());

    $("#contentDetailsId").text($(cols[4]).text());

    console.log($("#contentDetailsId").text());

    $("#contentDate").text($(cols[5]).text());

    $("#btnAddContentDetalle").text("Actualizar");
}

function ContentDetailBuildTableRow(id, fileExte) {
    let img = fImg(fileExte);

    $("#myTableContentDetalle tbody").append(
        MyTable(id, fileExte, img)
    );

    $("#divContentDetalle table").append(
        DivTable(id, fileExte)
    );

    formClear();
}

function MyTable(id, fileExten, img) {
    let ret = "<tr>" +
        "<td width='10%'>" + $("#contentTitle").val() + "</td>" +
        "<td width='72%'>" + $("#contentText").val() + "</td>" +
        img +
        "<td style='display: none;'>" + fileExten + "</td>" +
        "<td style='display: none;'>" + id + "</td>" +
        "<td style='display: none;'>01/01/2022</td>" +
        "<td width='8%'><button class='btn btn-sm btn-warning' type='button' onclick='ContentDetailEdit(this)' data-id='" + id + "'><i class='bi bi-pencil-fill'></i></button> |" +
        "<button class='btn btn-sm btn-danger' type='button' onclick='ContentDetailDelete(this)' data-id='" + id + "'><i class='bi bi-trash2'></i></button></td>" +
        "</tr>";

    return ret;
}
function DivTable(id, fileExten) {
    let isEsta = 0;

    if (fileExten.includes(".png") || fileExten.includes(".pdf")) {
        isEsta = 1;
    }

    let ret = "<input type='hidden' name='ContentDetails.Index' value=" + id + " /> " +
        "<input id=ContentTitle" + id + " type='hidden' name='ContentDetails[" + id + "].ContentTitle' value='" + $("#contentTitle").val() + "'/> " +
        "<input id=ContentText" + id + " type='hidden' name='ContentDetails[" + id + "].ContentText' value='" + $("#contentText").val() + "'/> " +
        "<input id=ContentUrlImg" + id + " type='hidden' name='ContentDetails[" + id + "].ContentUrlImg' value='" + fileExten + "'/> " +
        "<input id=isEsta" + id + " type='hidden' name='ContentDetails[" + id + "].isEsta' value='" + isEsta + "'/> ";

    return ret;
}
function fImg(fileExten) {
    let img = "";

    if (fileExten.includes(".pdf")) {
        img = "<td width='10%'><a href='" + fileExten + "' target='_blank'><i class='bi bi-file-earmark-pdf-fill' style='font-size:30px;'></i></a></td>";
    } else if (fileExten.includes(".png")) {
        img = "<td width='10%'><img src='" + fileExten + "' class='img-rounded' alt='Image' style='width: 100px; height: 100px; max-width: 100 %; height: auto;'/></td>";
    } else {
        img = "<td width='10%'><iframe width='40' height='20' src='" + fileExten + "' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe></td>"
    }

    return img;
}
function myTableContentDetalleDelete(ctl) {
    var count = $("#myTableContentDetalle tr").length - 1;

    var index = $(ctl).closest("tr").index();

    $(ctl).parents("tr").remove();

    $("input[value='" + index + "']").remove();
    $("input[name='ContentDetails[" + index + "].ContentTitle']").remove();
    $("input[name='ContentDetails[" + index + "].ContentText']").remove();
    $("input[name='ContentDetails[" + index + "].ContentUrlImg']").remove();
    $("input[name='ContentDetails[" + index + "].ContentUrlImg']").after();

    numD--;

}
function ContentDetailUpdateInTable(id, fileCadena) {

    var row = $("#myTableContentDetalle button[data-id='" + id + "']")
        .parents("tr")[0];

    let img = fImg(fileCadena);

    $(row).after(MyTable(id, fileCadena, img));

    $(row).remove();

    let InputName = "";

    if (fileCadena != "") {
        InputName = 'ContentUrlImg' + id;
        document.getElementById(InputName).value = fileCadena;
    }

    InputName = 'ContentTitle' + id;
    document.getElementById(InputName).value = $("#contentTitle").val();
    InputName = 'ContentText' + id;
    document.getElementById(InputName).value = $("#contentText").val();

    formClear();

    $("#btnAddContentDetalle").text("Agregar");

}

function formClear() {
    $("#contentTitle").val("");
    $("#contentText").val("");
    $("#contentUrlImg").val("");
    $("#dynamicCtr").empty();
    $("#OptionFile").val("");
}

$(document).ready(function () {

    $("#OptionFile").change(function () {
        $("#dynamicCtr").empty();
        if ($("#OptionFile").val() == "1") {
            $("#dynamicCtr").append("<div class='form-group' id='inputFile'><input id='contentUrlImg' class='form-control' type='file' accept='application/pdf, image/gif, image/jpeg, image/png'/><span id='spanContentUrlImg' class='text-danger'></span></div>");
        }
        else if ($("#OptionFile").val() == "2") {
            $("#dynamicCtr").append("<input id='contentUrlImg' class='form-control' maxlength='150' placeholder='Digite una url'/><span id='spanContentUrlImg' class='text-danger'></span>");
        }
    });

    let strategicLine = 0;
    let strategicLineSector = 0;

    $("#pqrsStrategicLineId").change(function () {

        var newVal = $(this).val();
        let a = document.getElementById("myTableContentDetalle");
        let lnRows = a.rows.length - 1;

        if (lnRows > 0) {
            if (!confirm("Realmente desea cambiar de linea estrategica?,la informacion del detalle se perderá.")) {
                $(this).val(strategicLine);
                return;
            }

            DeleteTable();
        }

        $("#pqrsStrategicLineSectorId").empty();

        $.ajax({
            type: 'POST',
            url: '/Prensa/getSector/',
            dataType: 'json',
            data: { Id: $("#pqrsStrategicLineId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#pqrsStrategicLineSectorId").append('<option value="'
                        + data.pqrsStrategicLineSectorId + '">'
                        + data.pqrsStrategicLineSectorName + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve cities.' + ex);
            }
        });

        strategicLine = newVal;
    })

    $("#pqrsStrategicLineSectorId").change(function () {
        var newVal = $(this).val();

        let a = document.getElementById("myTableContentDetalle");
        let lnRows = a.rows.length - 1;

        if (lnRows > 0) {

            if (!confirm("Realmente desea cambiar el sector ?,la informacion del detalle se perderá.")) {
                $(this).val(strategicLineSector);
                return;
            }

            DeleteTable();
        }

        strategicLineSector = newVal;
    });

});

function DeleteTable() {

    let a = document.getElementById("myTableContentDetalle");
    let rows = a.rows.length - 1;

    for (var index = 0; index < rows; index++) {

        var fileDelete = $("input[name='ContentDetails[" + index + "].isEsta']").val();
        if (fileDelete == "1") {
            FileDelete($("input[name='ContentDetails[" + index + "].ContentUrlImg']").val());
        }

        $("input[value='" + index + "']").remove();
        $("input[name='ContentDetails[" + index + "].ContentTitle']").remove();
        $("input[name='ContentDetails[" + index + "].ContentText']").remove();
        $("input[name='ContentDetails[" + index + "].ContentUrlImg']").remove();
        $("input[name='ContentDetails[" + index + "].isEsta']").remove();
    }

    $("#myTableContentDetalle tbody tr").remove();

    numD = 0;
}

function FileDelete(path) {
    $.ajax({
        type: "POST",
        url: urlServidor + "Contents/DeleteTemp",
        data: { file: path },
        success: function (data) {

        },
        error: function (ex) {
            alert('Failed to delete file.' + ex);
        }
    });
}