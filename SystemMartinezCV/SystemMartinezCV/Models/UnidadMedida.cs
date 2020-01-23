using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class UnidadMedida
    {
        public int IdUnidadMedida { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Productos> Productos { get; set; }
    }
}