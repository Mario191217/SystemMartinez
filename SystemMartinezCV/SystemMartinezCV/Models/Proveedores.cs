using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Representante { get; set; }
        public string Direccion { get; set; }
        public string NIT { get; set; }
        public string NRC { get; set; }
        public string Email { get; set; }
        public string NumeroCuenta { get; set; }
        public string Observacion { get; set; }
        public string Telefono { get; set; }
        public string TelefonoRepresentante { get; set; }
        public string EstadoEliminar { get; set; }
    }
}