window.onload = function () {


    let ContentProducto = document.getElementById("content-productos-carrito");
    let ProductosList = [];



    // Obtenemos los Productos Agregados 
    function GetCarritoCompras() {

        if (localStorage.getItem("DetalleCarrito")) {
            let CarritoJson = localStorage.getItem("DetalleCarrito");
            let JsonCarrito = JSON.parse(CarritoJson);

            for (let i = 0; i < JsonCarrito.length; i++) {
                ProductosList.push(JsonCarrito[i]);
            }
            console.log("Carrito tiene estos Productos : ", ProductosList)
        }
        else {
            console.log("Carrito Vacio")
        }
    };

    function LLenarTablaCarrito() {

        let tableBody = document.createElement("tbody");
        ContentProducto.appendChild(tableBody);

        ProductosList.forEach((v, i) => {

            let row = document.createElement("tr");

            row.innerHTML = `
                <td> <input type='hidden' value='${v.pkProducto}'  />  <strong> ${v.nombre} </strong>   </td>
                <td> <button id='DesCant' class='btn btn-primary btn-sm' style='width: 30px;'> - </button> <input id='cantidad' class='form-control form-control-sm' style='text-align: center; width: 30px; display: inline-block;' value='1' type='text' /> <button id='AunCant' class='btn btn-primary btn-sm' style='width: 30px;'> + </button> </td>
                <td> <input type='text' style='text-align: center; width: 80px; display: inline-block;' value='${v.precioventa}' /> </td>
                <td> <input type='text' style='text-align: center; width: 80px; display: inline-block;' /> </td>
                <td> <button class='btn btn-danger btn-sm'> <i class="far fa-trash-alt"></i> </button>  </td>
            `;

            tableBody.appendChild(row);
        });
    }

    
    GetCarritoCompras();
    LLenarTablaCarrito();

    //let DesCant = document.querySelectorAll("#DesCant");
    //let txtcantidad = document.querySelectorAll("#cantidad");

    //DesCant.forEach((v, i) => {
    //    DesCant[i].addEventListener("click", function (e) {
    //        e.preventDefault();
    //        let valor = txtcantidad[i].value;
    //        let valor2 = parseInt(valor) + 1;
    //        txtcantidad[i] = parseInt(valor2);
    //        console.log(txtcantidad[i].value);
    ////        console.log(valor2)
    ////    });
    ////});
    //console.log(DesCant)

};