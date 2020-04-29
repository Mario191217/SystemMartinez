namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectos", "Costo", c => c.Double(nullable: false));
            DropColumn("dbo.Proyectos", "CostoTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proyectos", "CostoTotal", c => c.Double(nullable: false));
            DropColumn("dbo.Proyectos", "Costo");
        }
    }
}
