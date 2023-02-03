using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumirApiRestBodega.Models.FolderDetalleFacturaModel
{
    public class SP_AgregarFacturaReturnData
    {
        public IEnumerable<int?> id_factura { get; set; }

        public string mensaje { get; set; }

    }
}