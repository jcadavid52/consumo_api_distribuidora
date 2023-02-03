using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumirApiRestBodega.Models
{
    public class AgregarDetalleModel
    {
        public int Cantidad_producto { get; set; }
        public double Descuento { get; set; }
        public int Fk_id_cliente { get; set; }
        public int Fk_id_usuario { get; set; }
        public int Fk_id_producto { get; set; }
        public int Fk_id_factura { get; set; }
    }
}