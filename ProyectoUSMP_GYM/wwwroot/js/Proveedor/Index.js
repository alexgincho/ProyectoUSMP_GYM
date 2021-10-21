$(document).ready(function () {

    let TableProveedor = $("#TableProveedor");
    let btnAddProveedor = $("#btnAddProveedor");

    btnAddProveedor.on("click", function (e) {
        e.preventDefault();
        InvocarModal();
    });
    // Funcion Invocar un Modal
    function InvocarModal(id) {
        AbrirModal(`/Proveedor/MantenimientoProveedor/${id ? id : ""}`);
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
    // Listado de Proveedor Consumiendo Datataables
    let DataTableProveedor = TableProveedor.DataTable({
        scrollY: 200,
        scrollX: true,
        paging: false,
        ordering: false,
        ajax: {
            url: '/Proveedor/GetAllProveedor',
        },
        columnDefs: [
            { targets: 0, width: 100 },
            { targets: 1, width: 110 },
            { targets: 2, width: 180 },
            { targets: 3, width: 180 },
            { targets: 4, width: 210 }
        ],
        columns: [
            { data: "ruc", title: "Ruc" },
            { data: "razonsocial", title: "Razon Social" },
            { data: "direccion", title: "Direccion" },
            { data: "email", title: "Email" },
            { data: "telefono", title: "Celular" },
            {
                data: null,
                defaultContent: "<button type='button' id='btnEditar' class='btn btn-primary'><i class='fas fa-pen-square'></i></i></button>",
                orderable: false,
                searchable: false,
                width: "26px"
            },
            { data: null, defaultContent: "<button type='button' id='btnEliminar' class='btn btn-danger'><i class='fas fa-trash-alt'></i></i></button>" }
        ]
    });
});