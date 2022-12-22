function deleteSwal(customerId) {
    swal({
        title: 'Esta usted seguro!',
        text: 'que quieres borrar esto?',
        icon: 'warning',
        buttons: ['No', 'Si'],
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "POST",
                url: "/PqrsUserStrategicLines/Delete",
                data: { id: customerId },
                success: function (response) {

                    if (response.status == true) {
                        $("#myModalDelete").modal('hide');
                        swal({ title: "Delete!", text: "Delete Successfuly", icon: "success", button: false, timer: 2500 }).then((value) => {
                            window.location.href = "/PqrsUserStrategicLines/Index";
                        });
                    } else {
                        $("#myModalDelete").modal('hide');
                        swal({ title: "Error", text: response.message, icon: "error", button: "Aceptar" }).then((value) => {
                            window.location.href = "/PqrsUserStrategicLines/Index";
                        });
                    }
                }
            });
        }
    });
}
