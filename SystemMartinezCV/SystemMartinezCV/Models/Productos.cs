using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EstadoEliminar { get; set; }

        public int IdUnidadMedida { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categorias Categorias { get; set; }
    }
}