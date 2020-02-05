using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemMartinezCV.Models;

namespace SystemMartinezCV
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<UnidadMedida> unidadMedida { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.Compras> Compras { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.DetalleCompra> DetalleCompras { get; set; }
    }
}