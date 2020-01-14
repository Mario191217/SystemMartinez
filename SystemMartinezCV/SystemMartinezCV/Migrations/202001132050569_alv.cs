namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alv : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblEmpleados", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblEmpleados", "Telefono", c => c.Int(nullable: false));
        }
    }
}
