namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prob : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleCompras", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.Compras", "IdProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.DetalleCompras", "IdCompra", "dbo.Compras");
            DropIndex("dbo.Compras", new[] { "IdProveedor" });
            DropIndex("dbo.DetalleCompras", new[] { "IdCompra" });
            DropIndex("dbo.DetalleCompras", new[] { "IdProducto" });
            DropTable("dbo.Compras");
            DropTable("dbo.DetalleCompras");
        }
    }
}
