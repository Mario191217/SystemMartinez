using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class UnidadMedida
    {
        [Key]
        public int IdUnidadMedida { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Productos> Productos { get; set; }
        public virtual List<DetalleProyectos> DetalleProyectos { get; set; }
    }
}