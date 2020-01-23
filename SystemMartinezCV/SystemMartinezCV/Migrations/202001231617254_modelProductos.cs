namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelProductos : DbMigration
    {
        public override void Up()
        {
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
                "dbo.UnidadMedidas",
                c => new
                    {
                        IdUnidadMedida = c.Int(nullable: false, identity: true),
                        Unidad = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdUnidadMedida);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "IdUnidadMedida", "dbo.UnidadMedidas");
            DropForeignKey("dbo.Productos", "IdCategoria", "dbo.Categorias");
            DropIndex("dbo.Productos", new[] { "IdCategoria" });
            DropIndex("dbo.Productos", new[] { "IdUnidadMedida" });
            DropTable("dbo.UnidadMedidas");
            DropTable("dbo.Productos");
            DropTable("dbo.Categorias");
        }
    }
}
