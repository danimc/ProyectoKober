using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMEPortal.Models
{
    public class Pedidos
    {
        public string Descripcion { get; set; }

        public string  RutaImagen { get; set; }
        public ICollection<Colores> Colores { get; set; }
        public ICollection<string> Ancho { get; set; }

        public ICollection<string> Largo { get; set; }

        public ICollection<PedidosDetalle> Detalle { get; set; }
    }

    public class Colores
    {
        public string Color { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
    }
    public class PedidosDetalle
    {
        public string Articulo { get; set; }
        public string Desripcion { get; set; }
        public decimal Cantidad { get; set; }
        public string Clasificacion { get; set; }
        public string Color { get; set; }
        public string ColorCodigo { get; set; }
        public string Largo { get; set; }
        public string Ancho { get; set; }
        public string Modelo { get; set; }

        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        //Acomodo de Grid:  Articulo, Descripción,  Cantidad, Cubierta o Barra, Color,  Largo, Ancho, Modelo, Premium o Estándar


    }
    public class ArticuloPick
    {
        public string ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public string Ancho { get; set; }
        public string Largo { get; set; }
        public string Clasificacion { get; set; }
        public string Estilo { get; set; }
        public double Cantidad { get; set; }
        public decimal? Precio { get; set; }

    }

    public class Articulos
    {
        public string Codigo { get; set; }
        public string Cantidad { get; set; }
    }


}