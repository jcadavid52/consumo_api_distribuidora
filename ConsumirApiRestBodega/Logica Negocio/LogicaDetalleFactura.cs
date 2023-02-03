using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ConsumirApiRestBodega.Models;
using Newtonsoft.Json;

namespace ConsumirApiRestBodega.Logica_Negocio
{
    public class LogicaDetalleFactura
    {
        //insertar detalle factura
        public static async Task<bool> AgregarDetalleFactura(AgregarDetalleModel detalleFactura,string token)
        {
           

            var cliente = new HttpClient();
           
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var content = new StringContent(JsonConvert.SerializeObject(detalleFactura), Encoding.UTF8,"application/json");

            var response = await cliente.PostAsync($"https://localhost:44326/api/detallefactura/add",content);
            
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        } 
    }
}