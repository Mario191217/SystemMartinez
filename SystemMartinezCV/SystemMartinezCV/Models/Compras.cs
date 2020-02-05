using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Compras
    {
        [Key]
        public int IdCompra { get; set; }
        public string NFactura { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdProveedor { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        public string Descripcion { get; set; }
        public string EstadoEliminar { get; set; }

        public virtual List<DetalleCompra> DetalleCompras { get; set; }
    }
}