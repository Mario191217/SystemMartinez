namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod : DbMigration
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
            
            AddColumn("dbo.Proyectos", "IdEmpleado", c => c.Int(nullable: false));
            AddColumn("dbo.Proyectos", "Comision", c => c.Double(nullable: false));
            CreateIndex("dbo.Proyectos", "IdEmpleado");
            AddForeignKey("dbo.Proyectos", "IdEmpleado", "dbo.TblEmpleados", "IdEmpleado", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectos", "IdEmpleado", "dbo.TblEmpleados");
            DropForeignKey("dbo.Abonos", "IdProyecto", "dbo.Proyectos");
            DropIndex("dbo.Proyectos", new[] { "IdEmpleado" });
            DropIndex("dbo.Abonos", new[] { "IdProyecto" });
            DropColumn("dbo.Proyectos", "Comision");
            DropColumn("dbo.Proyectos", "IdEmpleado");
            DropTable("dbo.Abonos");
        }
    }
}
