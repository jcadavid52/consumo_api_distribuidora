using ConsumirApiRestBodega.Models.FolderUsuarioModel;
using ConsumirApiRestBodega.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsumirApiRestBodega.Logica_Negocio
{
    public class LogicaLogin
    {
        public async Task<string> ObtenerToken(UsuarioModel usuarioModel)
        {
            var token = "";
            var cliente = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(usuarioModel), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"https://localhost:44326/api/usuario/Autenticacion", content);

            if (!response.IsSuccessStatusCode)
            {
                return token;
            }
            var resultado = await response.Content.ReadAsStringAsync();
            var resultadoToken = JsonConvert.DeserializeObject<UserToken>(resultado);
            token = resultadoToken.token;

            return token;
        }
    }
}