using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }
        public int IdProducto { get; set; }
        public virtual Productos Productos { get; set; }
        public int IdCompra { get; set; }
        public virtual Compras Compras { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }
    }
}