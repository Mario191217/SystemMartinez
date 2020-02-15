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
        public DateTime Fecha { get; set; }
        //public string DetalleProyecto { get; set; }
        // producto puede ser de existencia, producto comprado o nombre de proveedor
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }
        public string Comentario { get; set; }
        //validar compra o existencias en inventario
        // compra = 0 == false, inventario = 1== true
        public bool Existencias { get; set; }
        //solamente se agrega en caso de ser compra
        public string NumeroFactura { get; set; }
        public int IdProyecto { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}