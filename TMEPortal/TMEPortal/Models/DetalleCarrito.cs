using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMEPortal.Models
{
    public class DetalleCarrito
    {
        public int id { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public string cliente { get; set; }
        public string Nombre { get; set; }
        public string Concepto { get; set; }
        public string Condicion { get; set; }
        public string Descuento { get; set; }
        public string OrdenCompra { get; set; }
        public List<FacturaDetalle> Detalle { get; set; }



        public class FacturaDetalle
        {
            public int id { get; set; }
            public int? idEncabezado { get; set; }
            public double? renglon { get; set; }
            public double? Cantidad { get; set; }
            public string Articulo { get; set; }           
            public string Descripcion { get; set; }
            public double? descuento { get; set; }
            public decimal? importe { get; set; }
            public decimal? impuesto { get; set; }
            public decimal? ImporteTotal { get; set; }
        }
    }
}