using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMEPortal.Models
{
    public class PedidosPendientesPorCliente
    {
        
        public int id { get; set; }
        public string mov { get; set; }
        public string movID { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public string Concepto { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }
        public string OrdenCompra { get; set; }
        public string Condicion { get; set; }
        public Nullable<System.DateTime> Vencimiento { get; set; }
        public Nullable<double> Descuento { get; set; }
        public Nullable<decimal> saldo { get; set; }
        public Nullable<decimal> importe { get; set; }
        public Nullable<decimal> impuestos { get; set; }
        public Nullable<double> subTotal { get; set; }
        public Nullable<System.DateTime> FechaRequerida { get; set; }
        public int PedidoId { get; set; }

        public List<FacturaDetalle> Detalle { get; set; }

        public class FacturaDetalle
        {

            public string Articulo { get; set; }
            public double? Cantidad { get; set; }
            public string Descripcion1 { get; set; }
            public double? Precio { get; set; }
            public double? SubTotal { get; set; }
            public double? Total { get; set; }

        }

    }

}