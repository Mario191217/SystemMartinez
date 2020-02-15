namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectos", "NumeroProyecto", c => c.Int(nullable: false));
            AddColumn("dbo.Proyectos", "Descripcion", c => c.String());
            AddColumn("dbo.Proyectos", "Rentabilidad", c => c.Double(nullable: false));
            AddColumn("dbo.Proyectos", "IdEstado", c => c.Int(nullable: false));
            AddColumn("dbo.DetalleProyectos", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.DetalleProyectos", "NumeroFactura", c => c.String());
            AddColumn("dbo.Extras", "Fecha", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Proyectos", "IdEstado");
            AddForeignKey("dbo.Proyectos", "IdEstado", "dbo.Estados", "IdEstado", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectos", "IdEstado", "dbo.Estados");
            DropIndex("dbo.Proyectos", new[] { "IdEstado" });
            DropColumn("dbo.Extras", "Fecha");
            DropColumn("dbo.DetalleProyectos", "NumeroFactura");
            DropColumn("dbo.DetalleProyectos", "Fecha");
            DropColumn("dbo.Proyectos", "IdEstado");
            DropColumn("dbo.Proyectos", "Rentabilidad");
            DropColumn("dbo.Proyectos", "Descripcion");
            DropColumn("dbo.Proyectos", "NumeroProyecto");
        }
    }
}
