function NuevoArticulo(id) {


    $.ajax({
        url: "/ProductosPortal/Create/" + id,
        success: function (result) {
            $("#modalContent").html(result);
            console.log(result);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });


    $('#myModal').modal('show');

}

