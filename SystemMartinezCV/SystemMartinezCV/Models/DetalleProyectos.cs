using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class DetalleProyectos
    {
        [Key]
        public int IdDetalleProyecto { get; set; }
        //public string DetalleProyecto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
        public string Comentario { get; set; }
        public bool Existencias { get; set; }

        public int IdProyecto { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}