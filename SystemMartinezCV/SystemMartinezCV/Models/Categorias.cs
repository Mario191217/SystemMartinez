using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemMartinezCV.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
    }
}