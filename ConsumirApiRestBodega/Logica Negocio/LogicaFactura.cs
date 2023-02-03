using ConsumirApiRestBodega.Models.FolderDetalleFacturaModel;
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
    public class LogicaFactura
    {
        public static async Task<SP_AgregarFacturaReturnData> AgregarFactura(AgregarFacturaModel Factura)
        {


            var cliente = new HttpClient();

         

            var content = new StringContent(JsonConvert.SerializeObject(Factura), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"https://localhost:44326/api/factura/add", content);

            var pk_facturaString = await response.Content.ReadAsStringAsync();

           

            var id_factura = JsonConvert.DeserializeObject<SP_AgregarFacturaReturnData>(pk_facturaString);
            

            if (response.IsSuccessStatusCode)
            {
                return id_factura;
            }     
            

            return null;
        }

        

    }
}