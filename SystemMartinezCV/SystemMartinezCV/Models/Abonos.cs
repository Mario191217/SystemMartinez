using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Abonos
    {
        [Key]
        public int IdAbono { get; set; }
        public string Codigo { get; set; }
        public double Abono { get; set; }
        public string Descripcion { get; set; }
        public int IdProyecto { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}