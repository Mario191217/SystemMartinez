namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        IdGenero = c.Int(nullable: false),
                        Direccion = c.String(),
                        DUI = c.String(),
                        Telefono = c.String(),
                        NRC = c.String(),
                        NIT = c.String(),
                        EstadoEliminar = c.String(),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Generos", t => t.IdGenero, cascadeDelete: true)
                .Index(t => t.IdGenero);
            
            CreateTable(
                "dbo.Generos",
                c => new
                    {
                        IdGenero = c.Int(nullable: false, identity: true),
                        Genero = c.String(),
                    })
                .PrimaryKey(t => t.IdGenero);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        IdProyecto = c.Int(nullable: false, identity: true),
                        Proyecto = c.String(),
                        IdCliente = c.String(),
                        MontoFinal = c.Double(nullable: false),
                        Ubicacion = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Clientes_IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.IdProyecto)
                .ForeignKey("dbo.Clientes", t => t.Clientes_IdCliente)
                .Index(t => t.Clientes_IdCliente);
            
            CreateTable(
                "dbo.DetalleProyectos",
                c => new
                    {
                        IdDetalleProyecto = c.Int(nullable: false, identity: true),
                        Producto = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Comentario = c.String(),
                        Existencias = c.Boolean(nullable: false),
                        IdProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleProyecto)
                .ForeignKey("dbo.Proyectos", t => t.IdProyecto, cascadeDelete: true)
                .Index(t => t.IdProyecto);
            
            CreateTable(
                "dbo.Extras",
                c => new
                    {
                        IdExtra = c.Int(nullable: false, identity: true),
                        Extra = c.String(),
                        Descripcion = c.String(),
                        Precio = c.Double(nullable: false),
                        IdProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdExtra)
                .ForeignKey("dbo.Proyectos", t => t.IdProyecto, cascadeDelete: true)
                .Index(t => t.IdProyecto);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        IdEstado = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            AddColumn("dbo.TblEmpleados", "IdGenero", c => c.Int(nullable: false));
            CreateIndex("dbo.TblEmpleados", "IdGenero");
            AddForeignKey("dbo.TblEmpleados", "IdGenero", "dbo.Generos", "IdGenero", cascadeDelete: true);
            DropColumn("dbo.TblEmpleados", "Genero");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblEmpleados", "Genero", c => c.String());
            DropForeignKey("dbo.Extras", "IdProyecto", "dbo.Proyectos");
            DropForeignKey("dbo.DetalleProyectos", "IdProyecto", "dbo.Proyectos");
            DropForeignKey("dbo.Proyectos", "Clientes_IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.TblEmpleados", "IdGenero", "dbo.Generos");
            DropForeignKey("dbo.Clientes", "IdGenero", "dbo.Generos");
            DropIndex("dbo.Extras", new[] { "IdProyecto" });
            DropIndex("dbo.DetalleProyectos", new[] { "IdProyecto" });
            DropIndex("dbo.Proyectos", new[] { "Clientes_IdCliente" });
            DropIndex("dbo.TblEmpleados", new[] { "IdGenero" });
            DropIndex("dbo.Clientes", new[] { "IdGenero" });
            DropColumn("dbo.TblEmpleados", "IdGenero");
            DropTable("dbo.Estados");
            DropTable("dbo.Extras");
            DropTable("dbo.DetalleProyectos");
            DropTable("dbo.Proyectos");
            DropTable("dbo.Generos");
            DropTable("dbo.Clientes");
        }
    }
}
