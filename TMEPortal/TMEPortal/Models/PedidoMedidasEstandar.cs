using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMEPortal.Models
{
    public class PedidoMedidasEstandar
    {
        public int id { get; set; }
        public string Linea { get; set; }
        public string Color { get; set; }
        public string Descripcion { get; set; }
        public int C240 { get; set; }
        public int C300 { get; set; }
        public int C360 { get; set; }
        public int B240 { get; set; }
        public int B300 { get; set; }
        public int B90240 { get; set; }
        public int Total { get; set; }

    }
}