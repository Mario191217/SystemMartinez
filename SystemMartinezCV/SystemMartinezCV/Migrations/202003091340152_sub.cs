namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proyectos", "CostoTotal", c => c.Double(nullable: false));
            AlterColumn("dbo.Extras", "Precio", c => c.Double());
            DropColumn("dbo.Proyectos", "Costo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proyectos", "Costo", c => c.Double(nullable: false));
            AlterColumn("dbo.Extras", "Precio", c => c.Double(nullable: false));
            DropColumn("dbo.Proyectos", "CostoTotal");
        }
    }
}
