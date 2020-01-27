using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    [Table("Tblusuarios")]
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        //[DataType(DataType.Password)]
        public string Clave { get; set; }

        public int IdEmpleado { get; set; }
        public virtual Empleados Empleados { get; set; }

        public int IdRol { get; set; }
        public virtual Roles Roles { get; set; }
    }
}