using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Extras
    {
        [Key]
        public int IdExtra { get; set; }
        public string Extra { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }

        public int IdProyecto { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}