$(function () {
    $("#SaveButton").click(function () {
        let programIds = [];
        $('.table td input[type="checkbox"]:checked').each(function () {
            let id = $(this).attr("data-id");
            programIds.push(parseInt(id));
        });

        if (Validate()) {
            if (programIds.length > 0) {
                var model = {
                    email: $("#email").val(),
                    TempChecks: programIds
                };

                $.ajax({
                    cache: false,
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    'dataType': 'json',
                    type: "POST",
                    url: "https://www.araucactiva.com/Subscribers/Index",
                    data: JSON.stringify(model),
                    success: function (data) {
                        if (data) {
                            var url = "https://www.araucactiva.com/Home/Index";
                            window.location.href = url;
                        } else {
                            alert("Lo sentimos. Hemos tenido un inconveniente para guardar la información!");
                        }
                    },
                    error: function (p1, p2, p3) {
                        alert("Lo sentimos. Hemos tenido un inconveniente para guardar la información!");
                    }
                });
            }

        }
    });
});
function Validate() {
    var isValid = true;

    $('#spanEmail').text('').show('hide');

    if ($('#email').val().trim() == '') {
        $('#spanEmail').text('!El campo es requerido¡').show();
        $('#email').focus();
        isValid = false;
    } else if (!ValidarEmail($('#email').val().trim())) {
        $('#spanEmail').text('!El email no es valido¡').show();
        $('#email').focus();
        isValid = false;
    }
    return isValid;
}

function ValidarEmail(email) {
    console.log("Entro ha validar..");
    let isValid = false;
    let regexEmail = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
    if (regexEmail.test(email)) {
        isValid = true;
    }
    console.log("Termino ha validar.." + isValid);

    return isValid;
}