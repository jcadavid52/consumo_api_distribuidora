using ConsumirApiRestBodega.Models.FolderClienteModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumirApiRestBodega.Controllers
{
    public class ClienteController : Controller
    {
        #region VISTAS
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Acciones POST

        #endregion

        #region Datos JSON
        [HttpPost]
        public async Task<JsonResult> ObtenerCliente(int id)
        {
            var httpClient = new HttpClient();



            var oClienteAPI = await httpClient.GetStringAsync("https://localhost:44326/api/cliente/get/" + id);
            var cliente = JsonConvert.DeserializeObject<Clientes>(oClienteAPI);

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }
        #endregion



    }
}