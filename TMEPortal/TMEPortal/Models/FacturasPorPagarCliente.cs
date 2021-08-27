using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMEPortal.Models
{
    public class FacturasPorPagarCliente
    {
        public string movid { get; set; }
        public string Orden_de_compra { get; set; }
        public string referencia { get; set; }
        public Nullable<double> importe { get; set; }
        public Nullable<decimal> impuestos { get; set; }
        public Nullable<double> saldo { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public Nullable<System.DateTime> Vencimiento { get; set; }
        public Nullable<int> DiasMoratorios { get; set; }

        public int PedidoId { get; set; }
        public List<FacturaDetalle> Detalle { get; set; }
    } 

    public  class FacturaDetalle
    {

        public string Articulo { get; set; }
        public double? Cantidad { get; set; }
       public string Descripcion1 { get; set; }
      public double? Precio { get; set; }
        public double? Total { get; set; }

    }

}