namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonos",
                c => new
                    {
                        IdAbono = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Abono = c.Double(nullable: false),
                        Descripcion = c.String(),
                        IdProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAbono)
                .ForeignKey("dbo.Proyectos", t => t.IdProyecto, cascadeDelete: true)
                .Index(t => t.IdProyecto);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        IdProyecto = c.Int(nullable: false, identity: true),
                        NumeroProyecto = c.Int(nullable: false),
                        Proyecto = c.String(),
                        Descripcion = c.String(),
                        IdCliente = c.Int(nullable: false),
                        MontoFinal = c.Double(nullable: false),
                        Costo = c.Double(nullable: false),
                        Ubicacion = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        Comision = c.Double(nullable: false),
                        Rentabilidad = c.Double(nullable: false),
                        IdEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProyecto)
                .ForeignKey("dbo.TblEmpleados", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.Estados", t => t.IdEstado, cascadeDelete: true)
                .Index(t => t.IdCliente)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdEstado);
            
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
                "dbo.TblEmpleados",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Dui = c.String(),
                        Nit = c.String(),
                        Seguro = c.String(),
                        AFP = c.String(),
                        Email = c.String(),
                        IdGenero = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        TelefonoEmergencia = c.String(),
                        EstadoEliminar = c.String(),
                        Observaciones = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpleado)
                .ForeignKey("dbo.Generos", t => t.IdGenero, cascadeDelete: false)
                .Index(t => t.IdGenero);
            
            CreateTable(
                "dbo.Tblusuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Clave = c.String(),
                        IdEmpleado = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.TblEmpleados", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.TblRoles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.TblRoles",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdRol);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        IdEstado = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            CreateTable(
                "dbo.Extras",
                c => new
                    {
                        IdExtra = c.Int(nullable: false, identity: true),
                        Extra = c.String(),
                        Descripcion = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Precio = c.Double(),
                        IdProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdExtra)
                .ForeignKey("dbo.Proyectos", t => t.IdProyecto, cascadeDelete: true)
                .Index(t => t.IdProyecto);
            
            CreateTable(
                "dbo.Subproyectos",
                c => new
                    {
                        IdSubProyecto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        IdProyecto = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        Costo = c.Double(nullable: false),
                        Rentabilidad = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdSubProyecto)
                .ForeignKey("dbo.Proyectos", t => t.IdProyecto, cascadeDelete: true)
                .Index(t => t.IdProyecto);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Categoria = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        EstadoEliminar = c.String(),
                        IdUnidadMedida = c.Int(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.Categorias", t => t.IdCategoria, cascadeDelete: true)
                .ForeignKey("dbo.UnidadMedidas", t => t.IdUnidadMedida, cascadeDelete: true)
                .Index(t => t.IdUnidadMedida)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        IdDetalleCompra = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        IdCompra = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleCompra)
                .ForeignKey("dbo.Compras", t => t.IdCompra, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto)
                .Index(t => t.IdCompra);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        IdCompra = c.Int(nullable: false, identity: true),
                        NFactura = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdProveedor = c.Int(nullable: false),
                        Descripcion = c.String(),
                        EstadoEliminar = c.String(),
                    })
                .PrimaryKey(t => t.IdCompra)
                .ForeignKey("dbo.Proveedores", t => t.IdProveedor, cascadeDelete: true)
                .Index(t => t.IdProveedor);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(),
                        Representante = c.String(),
                        Direccion = c.String(),
                        NIT = c.String(),
                        NRC = c.String(),
                        Email = c.String(),
                        NumeroCuenta = c.String(),
                        Observacion = c.String(),
                        Telefono = c.String(),
                        TelefonoRepresentante = c.String(),
                        EstadoEliminar = c.String(),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
            CreateTable(
                "dbo.UnidadMedidas",
                c => new
                    {
                        IdUnidadMedida = c.Int(nullable: false, identity: true),
                        Unidad = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdUnidadMedida);
            
            CreateTable(
                "dbo.DetalleProyectos",
                c => new
                    {
                        IdDetalleProyecto = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Producto = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        IdUnidadMedida = c.Int(nullable: false),
                        Comentario = c.String(),
                        Existencias = c.Boolean(nullable: false),
                        NumeroFactura = c.String(),
                        IdSubProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleProyecto)
                .ForeignKey("dbo.Subproyectos", t => t.IdSubProyecto, cascadeDelete: true)
                .ForeignKey("dbo.UnidadMedidas", t => t.IdUnidadMedida, cascadeDelete: true)
                .Index(t => t.IdUnidadMedida)
                .Index(t => t.IdSubProyecto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "IdUnidadMedida", "dbo.UnidadMedidas");
            DropForeignKey("dbo.DetalleProyectos", "IdUnidadMedida", "dbo.UnidadMedidas");
            DropForeignKey("dbo.DetalleProyectos", "IdSubProyecto", "dbo.Subproyectos");
            DropForeignKey("dbo.DetalleCompras", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.Compras", "IdProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.DetalleCompras", "IdCompra", "dbo.Compras");
            DropForeignKey("dbo.Productos", "IdCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Subproyectos", "IdProyecto", "dbo.Proyectos");
            DropForeignKey("dbo.Extras", "IdProyecto", "dbo.Proyectos");
            DropForeignKey("dbo.Proyectos", "IdEstado", "dbo.Estados");
            DropForeignKey("dbo.Proyectos", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Tblusuarios", "IdRol", "dbo.TblRoles");
            DropForeignKey("dbo.Tblusuarios", "IdEmpleado", "dbo.TblEmpleados");
            DropForeignKey("dbo.Proyectos", "IdEmpleado", "dbo.TblEmpleados");
            DropForeignKey("dbo.TblEmpleados", "IdGenero", "dbo.Generos");
            DropForeignKey("dbo.Clientes", "IdGenero", "dbo.Generos");
            DropForeignKey("dbo.Abonos", "IdProyecto", "dbo.Proyectos");
            DropIndex("dbo.DetalleProyectos", new[] { "IdSubProyecto" });
            DropIndex("dbo.DetalleProyectos", new[] { "IdUnidadMedida" });
            DropIndex("dbo.Compras", new[] { "IdProveedor" });
            DropIndex("dbo.DetalleCompras", new[] { "IdCompra" });
            DropIndex("dbo.DetalleCompras", new[] { "IdProducto" });
            DropIndex("dbo.Productos", new[] { "IdCategoria" });
            DropIndex("dbo.Productos", new[] { "IdUnidadMedida" });
            DropIndex("dbo.Subproyectos", new[] { "IdProyecto" });
            DropIndex("dbo.Extras", new[] { "IdProyecto" });
            DropIndex("dbo.Tblusuarios", new[] { "IdRol" });
            DropIndex("dbo.Tblusuarios", new[] { "IdEmpleado" });
            DropIndex("dbo.TblEmpleados", new[] { "IdGenero" });
            DropIndex("dbo.Clientes", new[] { "IdGenero" });
            DropIndex("dbo.Proyectos", new[] { "IdEstado" });
            DropIndex("dbo.Proyectos", new[] { "IdEmpleado" });
            DropIndex("dbo.Proyectos", new[] { "IdCliente" });
            DropIndex("dbo.Abonos", new[] { "IdProyecto" });
            DropTable("dbo.DetalleProyectos");
            DropTable("dbo.UnidadMedidas");
            DropTable("dbo.Proveedores");
            DropTable("dbo.Compras");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Productos");
            DropTable("dbo.Categorias");
            DropTable("dbo.Subproyectos");
            DropTable("dbo.Extras");
            DropTable("dbo.Estados");
            DropTable("dbo.TblRoles");
            DropTable("dbo.Tblusuarios");
            DropTable("dbo.TblEmpleados");
            DropTable("dbo.Generos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Proyectos");
            DropTable("dbo.Abonos");
        }
    }
}
