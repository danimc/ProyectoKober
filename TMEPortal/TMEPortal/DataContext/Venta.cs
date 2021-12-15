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
    
    public partial class Venta
    {
        public int ID { get; set; }
        public string Empresa { get; set; }
        public string Mov { get; set; }
        public string MovID { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public Nullable<System.DateTime> UltimoCambio { get; set; }
        public string Concepto { get; set; }
        public string Proyecto { get; set; }
        public string Moneda { get; set; }
        public Nullable<double> TipoCambio { get; set; }
        public string Usuario { get; set; }
        public string Autorizacion { get; set; }
        public string Referencia { get; set; }
        public Nullable<int> DocFuente { get; set; }
        public string Observaciones { get; set; }
        public string Estatus { get; set; }
        public string Situacion { get; set; }
        public Nullable<System.DateTime> SituacionFecha { get; set; }
        public bool Directo { get; set; }
        public string Prioridad { get; set; }
        public Nullable<int> RenglonID { get; set; }
        public string Cliente { get; set; }
        public Nullable<int> EnviarA { get; set; }
        public string Almacen { get; set; }
        public string AlmacenDestino { get; set; }
        public string Agente { get; set; }
        public string FormaEnvio { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public Nullable<System.DateTime> FechaRequerida { get; set; }
        public Nullable<System.DateTime> FechaProgramadaEnvio { get; set; }
        public Nullable<System.DateTime> FechaOrdenCompra { get; set; }
        public string OrdenCompra { get; set; }
        public string Condicion { get; set; }
        public Nullable<System.DateTime> Vencimiento { get; set; }
        public string CtaDinero { get; set; }
        public string Descuento { get; set; }
        public Nullable<double> DescuentoGlobal { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public Nullable<decimal> Impuestos { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<decimal> DescuentoLineal { get; set; }
        public Nullable<decimal> ComisionTotal { get; set; }
        public Nullable<int> Paquetes { get; set; }
        public string ServicioTipo { get; set; }
        public string ServicioArticulo { get; set; }
        public string ServicioSerie { get; set; }
        public string ServicioContrato { get; set; }
        public string ServicioContratoID { get; set; }
        public string ServicioContratoTipo { get; set; }
        public bool ServicioGarantia { get; set; }
        public string ServicioDescripcion { get; set; }
        public Nullable<System.DateTime> ServicioFecha { get; set; }
        public string OrigenTipo { get; set; }
        public string Origen { get; set; }
        public string OrigenID { get; set; }
        public string Poliza { get; set; }
        public string PolizaID { get; set; }
        public bool GenerarPoliza { get; set; }
        public Nullable<int> Ejercicio { get; set; }
        public Nullable<int> Periodo { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaConclusion { get; set; }
        public Nullable<System.DateTime> FechaCancelacion { get; set; }
        public Nullable<double> Peso { get; set; }
        public Nullable<double> Volumen { get; set; }
        public bool Logico1 { get; set; }
        public bool Logico2 { get; set; }
        public bool Logico3 { get; set; }
        public bool Logico4 { get; set; }
        public bool Extra1 { get; set; }
        public bool Extra2 { get; set; }
        public bool Extra3 { get; set; }
        public bool Extra { get; set; }
        public Nullable<decimal> PrecioTotal { get; set; }
        public Nullable<decimal> CostoTotal { get; set; }
        public Nullable<System.DateTime> FechaOriginal { get; set; }
        public string Causa { get; set; }
        public Nullable<decimal> AnticiposFacturados { get; set; }
        public Nullable<int> ContID { get; set; }
        public string Atencion { get; set; }
        public Nullable<decimal> Retencion { get; set; }
        public Nullable<int> CancelacionID { get; set; }
        public string ServicioIdentificador { get; set; }
        public string AtencionTelefono { get; set; }
        public Nullable<int> Mensaje { get; set; }
        public string ListaPreciosEsp { get; set; }
        public string ZonaImpuesto { get; set; }
        public string EmbarqueEstado { get; set; }
        public Nullable<int> Departamento { get; set; }
        public int Sucursal { get; set; }
        public int SucursalOrigen { get; set; }
        public Nullable<int> SucursalDestino { get; set; }
        public byte[] SincroID { get; set; }
        public Nullable<int> SincroC { get; set; }
        public Nullable<bool> GenerarOP { get; set; }
        public Nullable<bool> DesglosarImpuestos { get; set; }
        public Nullable<bool> ExcluirPlaneacion { get; set; }
        public string HoraRequerida { get; set; }
        public Nullable<bool> ConVigencia { get; set; }
        public Nullable<System.DateTime> VigenciaDesde { get; set; }
        public Nullable<System.DateTime> VigenciaHasta { get; set; }
        public Nullable<decimal> Enganche { get; set; }
        public Nullable<double> Bonificacion { get; set; }
        public Nullable<double> IVAFiscal { get; set; }
        public Nullable<bool> EstaImpreso { get; set; }
        public string Periodicidad { get; set; }
        public string SubModulo { get; set; }
        public string ContUso { get; set; }
        public string AutoCorrida { get; set; }
        public string AutoBoleto { get; set; }
        public Nullable<decimal> EmbarqueGastos { get; set; }
        public Nullable<decimal> AnticiposImpuestos { get; set; }
        public Nullable<decimal> DifCredito { get; set; }
        public string Espacio { get; set; }
        public Nullable<bool> EspacioResultado { get; set; }
        public Nullable<int> UEN { get; set; }
        public string Clase { get; set; }
        public string Subclase { get; set; }
        public Nullable<int> AutoKms { get; set; }
        public Nullable<int> AutoKmsActuales { get; set; }
        public string AutoBomba { get; set; }
        public Nullable<int> AutoBombaContador { get; set; }
        public string AutoCorridaHora { get; set; }
        public string AutoCorridaServicio { get; set; }
        public string AutoCorridaRol { get; set; }
        public string AutoCorridaOrigen { get; set; }
        public string AutoCorridaDestino { get; set; }
        public Nullable<int> AutoCorridaKms { get; set; }
        public Nullable<int> AutoCorridaLts { get; set; }
        public string AutoCorridaRuta { get; set; }
        public string GastoAcreedor { get; set; }
        public string GastoConcepto { get; set; }
        public string Comentarios { get; set; }
        public Nullable<double> Pagado { get; set; }
        public Nullable<bool> GenerarDinero { get; set; }
        public string Dinero { get; set; }
        public string DineroID { get; set; }
        public string DineroCtaDinero { get; set; }
        public Nullable<bool> DineroConciliado { get; set; }
        public Nullable<System.DateTime> DineroFechaConciliacion { get; set; }
        public Nullable<bool> Reabastecido { get; set; }
        public string ServicioPlacas { get; set; }
        public string ServicioSiniestro { get; set; }
        public Nullable<int> ServicioKms { get; set; }
        public string ServicioTipoOrden { get; set; }
        public string ServicioTipoOperacion { get; set; }
        public Nullable<bool> ServicioExpress { get; set; }
        public bool ServicioDemerito { get; set; }
        public bool ServicioDeducible { get; set; }
        public Nullable<double> ServicioNumero { get; set; }
        public string AgenteServicio { get; set; }
        public Nullable<int> SucursalVenta { get; set; }
        public string ServicioNumeroEconomico { get; set; }
        public string ServicioAseguradora { get; set; }
        public Nullable<decimal> ServicioDeducibleImporte { get; set; }
        public Nullable<bool> AF { get; set; }
        public string AFArticulo { get; set; }
        public string AFSerie { get; set; }
        public string ContratoTipo { get; set; }
        public string ContratoDescripcion { get; set; }
        public string ContratoSerie { get; set; }
        public Nullable<decimal> ContratoValor { get; set; }
        public string ContratoValorMoneda { get; set; }
        public string ContratoSeguro { get; set; }
        public Nullable<System.DateTime> ContratoVencimiento { get; set; }
        public string ContratoResponsable { get; set; }
        public Nullable<bool> ServicioFlotilla { get; set; }
        public Nullable<bool> ServicioRampa { get; set; }
        public Nullable<decimal> Incentivo { get; set; }
        public Nullable<double> IEPSFiscal { get; set; }
        public string EndosarA { get; set; }
        public Nullable<bool> DesglosarImpuesto2 { get; set; }
        public Nullable<int> AnexoID { get; set; }
        public Nullable<bool> TMEGeneroOc { get; set; }
        public string IncentivoConcepto { get; set; }
        public Nullable<bool> FordVisitoOASIS { get; set; }
        public string LineaCredito { get; set; }
        public string TipoAmortizacion { get; set; }
        public string TipoTasa { get; set; }
        public string AutoOperador2 { get; set; }
        public Nullable<decimal> Comisiones { get; set; }
        public Nullable<decimal> ComisionesIVA { get; set; }
        public Nullable<int> CompraID { get; set; }
        public Nullable<bool> ServicioPuntual { get; set; }
        public Nullable<bool> OperacionRelevante { get; set; }
        public Nullable<double> AgenteComision { get; set; }
        public Nullable<bool> TieneTasaEsp { get; set; }
        public Nullable<double> TasaEsp { get; set; }
        public string ServicioPoliza { get; set; }
        public string SituacionUsuario { get; set; }
        public string SituacionNota { get; set; }
        public string ReferenciaOrdenCompra { get; set; }
        public Nullable<bool> EnvioMAIL { get; set; }
        public Nullable<double> SobrePrecio { get; set; }
        public string FormaPagoTipo { get; set; }
        public string TMEws_id { get; set; }
        public string TMEws_status { get; set; }
        public string CFDFlexEstatus { get; set; }
        public Nullable<bool> CFDTimbrado { get; set; }
        public string TMEEsProyecto { get; set; }
        public string DescuentoLinealEsp { get; set; }
        public string DescuentoGlobalEsp { get; set; }
        public string Prospecto { get; set; }
        public Nullable<bool> TMEGeneroOp { get; set; }
        public string TMEMovFac { get; set; }
        public string TMEMovIDFac { get; set; }
        public Nullable<bool> TMERegresoAlmacen { get; set; }
        public Nullable<double> InteresTasa { get; set; }
        public Nullable<double> InteresIva { get; set; }
        public Nullable<bool> AnticipoFacturadoTipoServicio { get; set; }
        public string codigo { get; set; }
        public string contuso2 { get; set; }
        public string contuso3 { get; set; }
        public string Actividad { get; set; }
        public Nullable<int> Contratoid { get; set; }
        public string ContratoMov { get; set; }
        public string ContratoMovid { get; set; }
        public string Posicion { get; set; }
        public Nullable<bool> TMENotificoAnticipoCte { get; set; }
        public Nullable<bool> TMEAgregarMaterialMKT { get; set; }
        public Nullable<double> TMECantidadMaterialMKT { get; set; }
        public Nullable<bool> TMEAplicadoMaterialMKT { get; set; }
        public Nullable<bool> EsParcial { get; set; }
        public Nullable<int> OXMLID { get; set; }
        public Nullable<int> DesarrolloOrigen { get; set; }
        public Nullable<bool> TmeRevisadoVConsig { get; set; }
    }
}
