using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using ConsumirApiRestBodega.Models;
using ConsumirApiRestBodega.Models.FolderClienteModel;
using ConsumirApiRestBodega.Models.FolderProductoModel;
using ConsumirApiRestBodega.Models.FolderUsuarioModel;
using ConsumirApiRestBodega.Models.FolderDetalleFacturaModel;
using System.Text;
using System.Net.Http.Headers;
using Rotativa;

namespace ConsumirApiRestBodega.Controllers
{
    public class DetalleFacturaController : Controller
    {
        #region Vistas

        public async Task<ActionResult> FormDF()
        {
            //validamos la sesión
            if (Session["token"] != null)
            {

                //llamar las api

                var httpClient = new HttpClient();

                var oClientes = await httpClient.GetStringAsync("https://localhost:44326/api/cliente/get");
           
                var oProductos = await httpClient.GetStringAsync("https://localhost:44326/api/producto/get");
           

                //desserializar objetos
                List<Clientes> datosClientes = JsonConvert.DeserializeObject<List<Clientes>>(oClientes);
                List<ProductoModel> datosProductos = JsonConvert.DeserializeObject<List<ProductoModel>>(oProductos);
         

            

                ViewBag.Clientes = datosClientes;
                ViewBag.Productos = datosProductos;
           

                return View();
            }

           return RedirectToAction("AutenticationView", "Login");
        }

        public async Task<ActionResult> FacturaView(SP_CONSULTAR_FACTURA_ResultModel factura)
        {
            var httpClient = new HttpClient();

            var MiJson = await httpClient.GetStringAsync("https://localhost:44326/api/factura/get/" + factura.codigo_factura);

            SP_CONSULTAR_FACTURA_ResultModel datos = JsonConvert.DeserializeObject<SP_CONSULTAR_FACTURA_ResultModel>(MiJson);

            return View(datos);
        }

        #endregion

        #region Acciones POST

        //agrega datos al detalle de la factura
        public async Task<ActionResult> insertarDetalleFactura(AgregarDetalleModel detalleFactura)
        {
            string token = Session["token"].ToString();

            var respuestaDetalleFactura = Logica_Negocio.LogicaDetalleFactura.AgregarDetalleFactura(detalleFactura,token);

            if (await respuestaDetalleFactura)
            {



                return Content("1");


            }

            return Content("2");

        }

        #region FACTURA

        //--ESTE MÓDULO DE MÉTODOS Y ACCIONES, SON PARA LAS FACTURAS-----

        //Se registra una factura y al mismo tiempo retorna la pk de esa factura
        public async Task<JsonResult> insertarFactura(AgregarFacturaModel nuevaFactura)
        {
            

            var respuestaFactura = await Logica_Negocio.LogicaFactura.AgregarFactura(nuevaFactura);

            if (respuestaFactura.mensaje == "0")
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else
            {

                if (respuestaFactura != null)
                {
              
                    return Json(respuestaFactura, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }




            
        }

        //imprimir PDF de la factura del cliente
        public async Task<ActionResult> Print(int id)
        {

            var httpClient = new HttpClient();

            var MiJson = await httpClient.GetStringAsync("https://localhost:44326/api/factura/get/" + id);

            SP_CONSULTAR_FACTURA_ResultModel datos = JsonConvert.DeserializeObject<SP_CONSULTAR_FACTURA_ResultModel>(MiJson);

            return new ActionAsPdf("FacturaView", datos)
            {
                FileName = "factura.pdf"
            };
        }


        //-------FIN MÓDULO DE FACTURA---------
        #endregion

        #endregion

        #region Datos JSON
        //data table:alimenta datos en tipo json
        [HttpPost]
        public async Task<JsonResult> Datos()
        {
            // obtenemos el token para pedir autorización de la api  
            string token = Session["token"].ToString();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var MiJson = await httpClient.GetStringAsync("https://localhost:44326/api/detallefactura/get");

            List<DetalleFacturaModel> datos = JsonConvert.DeserializeObject<List<DetalleFacturaModel>>(MiJson);


            return Json(new { data = datos });
           
        }

        //alimentar datos de fk_cliente
        public async Task<JsonResult> CodigosCliente()
        {
            // obtenemos el token para pedir autorización de la api  
            string token = Session["token"].ToString();

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var oCodigoClientes = await httpClient.GetStringAsync("https://localhost:44326/api/detallefactura/get");

            List<DetalleFacturaModel> codigosClientes = JsonConvert.DeserializeObject<List<DetalleFacturaModel>>(oCodigoClientes);

            //agrupar codigos del cliente existenetes solo en el detalle factura 
            var groupCodeClient = codigosClientes.GroupBy(x => x.FK_ID_CLIENTE);

            List<DetalleFacturaModel> listaCodigo = new List<DetalleFacturaModel>();


            //iterar los resultados y convertirlo en objeto lista detalle factura para poderlo recibir en la vista
            foreach (var item in groupCodeClient)
            {
                DetalleFacturaModel odetalle = new DetalleFacturaModel();

                odetalle.FK_ID_CLIENTE = item.Key;

                listaCodigo.Add(odetalle);
            }

            

            return Json(listaCodigo, JsonRequestBehavior.AllowGet);
        }

        
        public async Task<JsonResult> ObtenerFactura(int id)
        {
            var httpClient = new HttpClient();

            var MiJson = await httpClient.GetStringAsync("https://localhost:44326/api/factura/get/" + id);

            SP_CONSULTAR_FACTURA_ResultModel datos = JsonConvert.DeserializeObject<SP_CONSULTAR_FACTURA_ResultModel>(MiJson);

            return Json(datos,JsonRequestBehavior.AllowGet);
        }

        #endregion







    }
}