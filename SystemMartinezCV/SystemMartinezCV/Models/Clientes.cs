using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Clientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string DUI{ get; set; }
        public string Telefono{ get; set; }
        public string NRC{ get; set; }
        public string NIT{ get; set; }
        public string EstadoEliminar{ get; set; }
    }
}