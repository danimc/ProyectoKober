//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMEPortal.DataContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class respuestaPagoMSI
    {
        public int id { get; set; }
        public Nullable<int> ModuloID { get; set; }
        public string mov { get; set; }
        public string movid { get; set; }
        public Nullable<int> sucursal { get; set; }
        public string cliente { get; set; }
        public string nombreCliente { get; set; }
        public string cp { get; set; }
        public string referencia { get; set; }
        public Nullable<System.DateTime> fechaRegistro { get; set; }
        public Nullable<decimal> importeTotal { get; set; }
        public Nullable<int> msi { get; set; }
        public Nullable<int> last4 { get; set; }
        public Nullable<int> mesExp { get; set; }
        public Nullable<int> anioExp { get; set; }
        public string tipo { get; set; }
        public string paymentIntent { get; set; }
    }
}
