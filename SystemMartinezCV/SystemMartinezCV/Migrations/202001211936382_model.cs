namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proveedores", "Email", c => c.String());
            AddColumn("dbo.Proveedores", "Telefono", c => c.String());
            AddColumn("dbo.Proveedores", "TelefonoRepresentante", c => c.String());
            AddColumn("dbo.Proveedores", "EstadoEliminar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proveedores", "EstadoEliminar");
            DropColumn("dbo.Proveedores", "TelefonoRepresentante");
            DropColumn("dbo.Proveedores", "Telefono");
            DropColumn("dbo.Proveedores", "Email");
        }
    }
}
