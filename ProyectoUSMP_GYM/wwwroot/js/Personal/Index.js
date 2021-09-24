$(document).ready(function () {

    let btnAddPersonal = $("#btnAddPersonal");

    btnAddPersonal.on("click", function (e) {
        e.preventDefault();
        InvocarModal();
    });
    // Funcion Invocar un Modal
    function InvocarModal(id) {
        AbrirModal(`/Personal/MantenimientoPersonal/${id ? id : ""}`);
    }
    // Funcion para Abrir un Modal
    function AbrirModal(url) {

        $.ajax({
            type: 'GET',
            url: url,
            dataType: "html",
            cache: false,
            success: function (data) {
                $('.modal-container').html(data).find('.modal').modal({
                    show: true
                });
            }
        });
    }
// Agregar Personal Administrativo
    $(".modal-container").on("click", "#btnSave", function (e) {
        e.preventDefault();
        let Personal = {

            "Dni": $("#Dni").val(),
            "Nombre": $("#Nombre").val(),
            "Apellidopaterno": $("#Apellidopaterno").val(),
            "Apellidomaterno": $("#Apellidomaterno").val(),
            "Telefono": $("#Telefono").val(),
            "Direccion": $("#Direccion").val(),
            "Email": $("#Email").val(),
            "FkRol": $("#FkRol").val(),
            "Usuario": $("#Usuario").val(),
            "Password": $("#Password").val()


        }
        $.ajax({
            url: '/Personal/CreatePersonal',
            data: JSON.stringify(Personal),
            type: 'POST',
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {

                console.log(data);
                
            },
            error: function (error) {
            }
        });

        
    });


});