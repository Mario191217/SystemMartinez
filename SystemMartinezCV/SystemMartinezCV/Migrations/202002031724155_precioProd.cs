namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class precioProd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Precio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Precio");
        }
    }
}
