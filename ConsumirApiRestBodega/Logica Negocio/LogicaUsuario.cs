using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ConsumirApiRestBodega.Logica_Negocio
{
    public class LogicaUsuario
    {
        public async Task<int> GetpkUser(string user)
        {
            var stringQueryWeb = "?user=" + user;
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44326/api/usuario/GetUserpk" + stringQueryWeb);
           
            var oUserAPI = await response.Content.ReadAsStringAsync();

            int pkUser = int.Parse(oUserAPI);

            return pkUser;
        }
    }
}