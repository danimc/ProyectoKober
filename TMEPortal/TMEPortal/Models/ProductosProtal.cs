using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMEPortal.Models
{
    public class ProductosProtal
    {
        public string Color { get; set; }
        public string Descripcion { get; set; }
        [Display(Name = "Cubierta 2.40")]
        public int Medida1 { get; set; }
        [Display(Name = "Cubierta 3.00")]
        public int Medida2 { get; set; }
        [Display(Name = "Cubierta 3.60")]
        public int Medida3 { get; set; }
        [Display(Name = "Barra 2.40")]
        public int Medida4 { get; set; }
        [Display(Name = "Barra 3.00")]
        public int Medida5 { get; set; }
        [Display(Name = "Barra 3.60")]
        public int Medida6 { get; set; }
        [Display(Name = "Barra 90 2.40")]
        public int Medida7 { get; set; }
        
    }
}