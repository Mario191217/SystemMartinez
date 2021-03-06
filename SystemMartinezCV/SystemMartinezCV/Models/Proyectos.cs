﻿using System;
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
        public int NumeroProyecto { get; set; }
        public string Proyecto { get; set; }
        public string Descripcion { get; set; }
        /////////////////////////////////////////////////////
        public int IdCliente { get; set; }
        public virtual Clientes Clientes { get; set; }
        /////////////////////////////////////////////////////
        public double MontoFinal { get; set; }
        public double Costo { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        /// 
        public int IdEmpleado { get; set; }
        public virtual Empleados Empleados { get; set; }
        public double Comision { get; set; }
        public double Rentabilidad { get; set; }
        /// 
        public int IdEstado { get; set; }
        public virtual Estados Estados { get; set; }

        public virtual List<Subproyectos> Subproyectos { get; set; }
        public virtual List<Extras> Extras { get; set; }
        public virtual List<Abonos> Abonos { get; set; }
    }
}