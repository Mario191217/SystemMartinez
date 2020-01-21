namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prov : DbMigration
    {
        public override void Up()
        {
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
                        NumeroCuenta = c.String(),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
            AddColumn("dbo.TblEmpleados", "Seguro", c => c.String());
            AddColumn("dbo.TblEmpleados", "AFP", c => c.String());
            AddColumn("dbo.TblEmpleados", "TelefonoEmergencia", c => c.String());
            AddColumn("dbo.TblEmpleados", "Observaciones", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblEmpleados", "Observaciones");
            DropColumn("dbo.TblEmpleados", "TelefonoEmergencia");
            DropColumn("dbo.TblEmpleados", "AFP");
            DropColumn("dbo.TblEmpleados", "Seguro");
            DropTable("dbo.Proveedores");
        }
    }
}
