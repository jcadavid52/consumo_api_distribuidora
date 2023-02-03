using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumirApiRestBodega.Models.FolderDetalleFacturaModel
{
    public class DatosTablaFacturaLista
    {
        public string nombre_producto { get; set; }
        public Nullable<double> precio_unidad { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<double> SubTotal_por_unidad { get; set; }
        public Nullable<double> Total_por_Unidad { get; set; }
    }
}