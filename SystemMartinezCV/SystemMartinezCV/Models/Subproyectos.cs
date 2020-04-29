using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Subproyectos
    {
        [Key]
        public int IdSubProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdProyecto { get; set; }
        public virtual Proyectos Proyectos { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public double Rentabilidad { get; set; }
    }
}