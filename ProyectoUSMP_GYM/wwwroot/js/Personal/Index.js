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
                console.log(data)
                $('.modal-container').html(data).find('.modal').modal({
                    show: true
                });
            }
        });
    }



});