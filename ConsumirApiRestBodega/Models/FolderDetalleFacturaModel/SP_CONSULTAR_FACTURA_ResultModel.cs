using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumirApiRestBodega.Models.FolderDetalleFacturaModel
{
    public class SP_CONSULTAR_FACTURA_ResultModel
    {
        public int codigo_factura { get; set; }
        public Nullable<double> total { get; set; }

        public Nullable<double> subTotal { get; set; }


        public List<DatosTablaFacturaLista> datosTablaFactura { get; set; }

     
       
    }
}