﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PayoutsEntities : DbContext
    {
        public PayoutsEntities()
            : base("name=PayoutsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Art> Art { get; set; }
        public virtual DbSet<Cte> Cte { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaD> VentaD { get; set; }
        public virtual DbSet<KeySucursal> KeySucursal { get; set; }
        public virtual DbSet<respuestaPagoMSI> respuestaPagoMSI { get; set; }
        public virtual DbSet<CFDVentaV33> CFDVentaV33 { get; set; }
    
        public virtual int spMSIRespuestaPago(Nullable<int> moduloID, string mov, string movid, Nullable<int> sucursal, string cliente, string nombreCliente, string cp, string referencia, Nullable<System.DateTime> fechaRegistro, Nullable<decimal> importeTotal, Nullable<int> msi, Nullable<int> last4, Nullable<int> mesExp, Nullable<int> anioExp, string tipo)
        {
            var moduloIDParameter = moduloID.HasValue ?
                new ObjectParameter("ModuloID", moduloID) :
                new ObjectParameter("ModuloID", typeof(int));
    
            var movParameter = mov != null ?
                new ObjectParameter("mov", mov) :
                new ObjectParameter("mov", typeof(string));
    
            var movidParameter = movid != null ?
                new ObjectParameter("movid", movid) :
                new ObjectParameter("movid", typeof(string));
    
            var sucursalParameter = sucursal.HasValue ?
                new ObjectParameter("sucursal", sucursal) :
                new ObjectParameter("sucursal", typeof(int));
    
            var clienteParameter = cliente != null ?
                new ObjectParameter("cliente", cliente) :
                new ObjectParameter("cliente", typeof(string));
    
            var nombreClienteParameter = nombreCliente != null ?
                new ObjectParameter("nombreCliente", nombreCliente) :
                new ObjectParameter("nombreCliente", typeof(string));
    
            var cpParameter = cp != null ?
                new ObjectParameter("cp", cp) :
                new ObjectParameter("cp", typeof(string));
    
            var referenciaParameter = referencia != null ?
                new ObjectParameter("referencia", referencia) :
                new ObjectParameter("referencia", typeof(string));
    
            var fechaRegistroParameter = fechaRegistro.HasValue ?
                new ObjectParameter("fechaRegistro", fechaRegistro) :
                new ObjectParameter("fechaRegistro", typeof(System.DateTime));
    
            var importeTotalParameter = importeTotal.HasValue ?
                new ObjectParameter("importeTotal", importeTotal) :
                new ObjectParameter("importeTotal", typeof(decimal));
    
            var msiParameter = msi.HasValue ?
                new ObjectParameter("msi", msi) :
                new ObjectParameter("msi", typeof(int));
    
            var last4Parameter = last4.HasValue ?
                new ObjectParameter("last4", last4) :
                new ObjectParameter("last4", typeof(int));
    
            var mesExpParameter = mesExp.HasValue ?
                new ObjectParameter("mesExp", mesExp) :
                new ObjectParameter("mesExp", typeof(int));
    
            var anioExpParameter = anioExp.HasValue ?
                new ObjectParameter("anioExp", anioExp) :
                new ObjectParameter("anioExp", typeof(int));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spMSIRespuestaPago", moduloIDParameter, movParameter, movidParameter, sucursalParameter, clienteParameter, nombreClienteParameter, cpParameter, referenciaParameter, fechaRegistroParameter, importeTotalParameter, msiParameter, last4Parameter, mesExpParameter, anioExpParameter, tipoParameter);
        }
    
        public virtual ObjectResult<spMSIVentaDetalle_Result> spMSIVentaDetalle(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spMSIVentaDetalle_Result>("spMSIVentaDetalle", idParameter);
        }
    
        public virtual ObjectResult<string> spMSKeySucursal(Nullable<int> suc)
        {
            var sucParameter = suc.HasValue ?
                new ObjectParameter("suc", suc) :
                new ObjectParameter("suc", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spMSKeySucursal", sucParameter);
        }
    }
}
