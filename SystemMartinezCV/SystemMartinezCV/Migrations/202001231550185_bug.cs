namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblEmpleados", "FechaRegistro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblEmpleados", "FechaRegistro");
        }
    }
}
