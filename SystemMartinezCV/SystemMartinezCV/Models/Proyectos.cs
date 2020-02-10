using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Proyectos
    {
        [Key]
        public int IdProyecto { get; set; }
        public string Proyecto { get; set; }
        /////////////////////////////////////////////////////
        public string IdCliente { get; set; }
        public virtual Clientes Clientes { get; set; }
        /////////////////////////////////////////////////////
        public double MontoFinal { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual List<DetalleProyectos> DetalleProyectos { get; set; }
        public virtual List<Extras> Extras { get; set; }
    }
}