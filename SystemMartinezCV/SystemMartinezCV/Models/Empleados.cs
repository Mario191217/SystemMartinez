using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    [Table("TblEmpleados")]
    public class Empleados
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dui { get; set; }
        [Display(Name ="NIT")]
        public string Nit { get; set; }
        public string Seguro { get; set; }
        public string AFP { get; set; }

        public string Email { get; set; }
        public string Genero { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelefonoEmergencia { get; set; }
        public string EstadoEliminar { get; set; }
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual List<Usuarios> Usuarios { get; set; }
    }
}