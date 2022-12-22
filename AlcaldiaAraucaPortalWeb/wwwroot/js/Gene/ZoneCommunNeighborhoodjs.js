const urlServidor = window.location.hostname == "localhost" || window.location.hostname == "127.0.0.1" ? "https://localhost:7292/" : "https://www.araucactiva.com/";

$(document).ready(function () {
    $("#zoneId").change(function () {
        $("#communeTownshipId").empty();
        $("#neighborhoodSidewalkId").empty();

        $("#neighborhoodSidewalkId").append('<option value="0">[Seleccione una opcion anterior]</option>');
        
        $.ajax({
            type: "POST",
            url: urlServidor + "ApplicationUsers/CommuneTownshipSearch",
            data: { ZoneId: $("#zoneId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#communeTownshipId").append('<option value="'
                        + data.communeTownshipId + '">'
                        + data.communeTownshipName + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve' + ex);
            }
        });
        return false;
    })

    $("#communeTownshipId").change(function () {
        $("#neighborhoodSidewalkId").empty();
        console.log("Huy");
        $.ajax({
            type: 'POST',
            url: urlServidor + 'ApplicationUsers/NeighborhoodSidewalkSearch',
            dataType: 'json',
            data: { CommuneTownshipId: $("#communeTownshipId").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#neighborhoodSidewalkId").append('<option value="'
                        + data.neighborhoodSidewalkId + '">'
                        + data.neighborhoodSidewalkName + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve.' + ex);
            }
        });
        return false;
    })

});