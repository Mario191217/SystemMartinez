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
        public Contexto() : base("Martinez")
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<UnidadMedida> unidadMedida { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Abonos> Abonos { get; set; }
        public System.Data.Entity.DbSet<SystemMartinezCV.Models.Compras> Compras { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.DetalleCompra> DetalleCompras { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.Clientes> Clientes { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.DetalleProyectos> DetalleProyectos { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.Proyectos> Proyectos { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.Estados> Estados { get; set; }

        public System.Data.Entity.DbSet<SystemMartinezCV.Models.Extras> Extras { get; set; }
    }
}