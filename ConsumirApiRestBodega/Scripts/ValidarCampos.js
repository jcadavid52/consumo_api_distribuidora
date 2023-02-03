

const inputs = document.querySelectorAll('#detalleForm input');
const form = document.getElementById("detalleForm");
let cantidad;
let descuento;

const camposVacios = {
    cantidad: false,
    descuento: false,
    cliente: false,
   // usuario: false,
    producto: false
}

const camposLogicos = {

    cantidad: false,
    descuento: false,

}

function validarFormulario(e) {
    //Comenzar el switch

    switch (e.target.name) {
        case "cantidad":
            cantidad = parseInt(e.target.value);
            if (e.target.value.length > 0) {

                camposVacios[e.target.name] = true;
                document.querySelector("#bloque-input-cantidad .mensaje__formulario-vacio").classList.remove("mensaje__formulario-vacio-activo");

                if (cantidad <= 0) {
                    document.querySelector("#bloque-input-cantidad .mensaje__logico").classList.add("mensaje__logico-activo")
                    camposLogicos[e.target.name] = false;
                } else {
                    camposLogicos[e.target.name] = true;
                    document.querySelector("#bloque-input-cantidad .mensaje__logico").classList.remove("mensaje__logico-activo")
                }
            } else {
                camposVacios[e.target.name] = false;
                document.querySelector("#bloque-input-cantidad .mensaje__logico").classList.remove("mensaje__logico-activo")
            }



            break;

        case "descuento":
            descuento = parseInt(e.target.value);
            if (e.target.value.length > 0) {

                camposVacios[e.target.name] = true;
                document.querySelector("#bloque-input-descuento .mensaje__formulario-vacio").classList.remove("mensaje__formulario-vacio-activo");

                if (descuento < 0) {
                    document.querySelector("#bloque-input-descuento .mensaje__logico").classList.add("mensaje__logico-activo")
                    camposLogicos[e.target.name] = false;
                } else {
                    camposLogicos[e.target.name] = true;
                    document.querySelector("#bloque-input-descuento .mensaje__logico").classList.remove("mensaje__logico-activo")
                }
            } else {
                camposVacios[e.target.name] = false;
                document.querySelector("#bloque-input-descuento .mensaje__logico").classList.remove("mensaje__logico-activo")
            }



            break;

        case "cliente":
            cliente = parseInt(e.target.value);
            if (cliente > 0) {

                camposVacios[e.target.name] = true;
                camposLogicos[e.target.name] = true;
                document.querySelector("#bloque-input-cliente .mensaje__formulario-vacio").classList.remove("mensaje__formulario-vacio-activo");




            } else {
                camposVacios[e.target.name] = false;
            }

            break;

        //case "usuario":
        //    usuario = e.target.value;
        //    if (usuario.length > 0) {

        //        camposVacios[e.target.name] = true;
        //        camposLogicos[e.target.name] = true;
        //        document.querySelector("#bloque-input-usuario .mensaje__formulario-vacio").classList.remove("mensaje__formulario-vacio-activo");




        //    } else {
        //        camposVacios[e.target.name] = false;
        //    }

        //    break;

        case "producto":
            producto = parseInt(e.target.value);
            if (producto > 0) {

                camposVacios[e.target.name] = true;
                camposLogicos[e.target.name] = true;
                document.querySelector("#bloque-input-producto .mensaje__formulario-vacio").classList.remove("mensaje__formulario-vacio-activo");




            } else {
                camposVacios[e.target.name] = false;
            }

            break;

        default:
            //si TODOS los campos están CORRECTOS
            if (camposVacios.cantidad && camposLogicos.cantidad && camposVacios.descuento && camposLogicos.descuento && camposVacios.cliente /*&& camposVacios.usuario*/ && camposVacios.producto) {
                alert("Datos enviados correctamente")
                return RegistrarDetalleFactura();
            } else {
                for (var i = 0; i < form.length; i++) {
                    if (form[i].type == "number") {

                        if (form[i].value.length == 0) {

                            document.querySelector(`#bloque-input-${form[i].name} .mensaje__formulario-vacio`).classList.add("mensaje__formulario-vacio-activo");

                        }

                    }

                    if (form[i].type != "number") {

                        if (form[i].value == 0) {

                            document.querySelector(`#bloque-input-${form[i].name} .mensaje__formulario-vacio`).classList.add("mensaje__formulario-vacio-activo");

                        }

                    }
                }
            }
            break;
    }

   
}

inputs.forEach((input) => {
    input.addEventListener('change', validarFormulario);
    input.addEventListener('keyup', validarFormulario);


});

//muestra el boton de pdf que esta en la plantilla de la ventan modal
function mostrarBotonPdf() {

    document.querySelector("#container-button-pdf").style.display = "block";

   
}


