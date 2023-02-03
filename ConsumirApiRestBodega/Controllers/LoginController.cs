using ConsumirApiRestBodega.Models.FolderUsuarioModel;
using ConsumirApiRestBodega.Utilidades;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ConsumirApiRestBodega.Logica_Negocio;
using System.Net.Http.Headers;

namespace ConsumirApiRestBodega.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        #region VISTAS
        public ActionResult AutenticationView()
        {
            

            return View();
        }
        #endregion

        #region ACCIONES

        public async Task<ActionResult> AutenticationAction(UsuarioModel usuarioModel)
        {
            var oHttpClient = new HttpClient();
            LogicaLogin oLogicaLogin = new LogicaLogin();
            LogicaUsuario oLogicaUsuario = new LogicaUsuario();

            var token = await oLogicaLogin.ObtenerToken(usuarioModel);

            if (token == "")
            {
                TempData["Mensaje"] = "Clave o usuario inválidos";
                return RedirectToAction("AutenticationView","Login");
            }

            Session["token"] = token;

            Session["pkUser"] = await oLogicaUsuario.GetpkUser(usuarioModel.USUARIO1);

          


            oHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);

            return RedirectToAction("FormDF", "DetalleFactura");
        }


        #endregion

    }
}