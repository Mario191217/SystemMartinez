namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clienteId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proyectos", "Clientes_IdCliente", "dbo.Clientes");
            DropIndex("dbo.Proyectos", new[] { "Clientes_IdCliente" });
            DropColumn("dbo.Proyectos", "IdCliente");
            RenameColumn(table: "dbo.Proyectos", name: "Clientes_IdCliente", newName: "IdCliente");
            AlterColumn("dbo.Proyectos", "IdCliente", c => c.Int(nullable: false));
            AlterColumn("dbo.Proyectos", "IdCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.Proyectos", "IdCliente");
            AddForeignKey("dbo.Proyectos", "IdCliente", "dbo.Clientes", "IdCliente", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proyectos", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Proyectos", new[] { "IdCliente" });
            AlterColumn("dbo.Proyectos", "IdCliente", c => c.Int());
            AlterColumn("dbo.Proyectos", "IdCliente", c => c.String());
            RenameColumn(table: "dbo.Proyectos", name: "IdCliente", newName: "Clientes_IdCliente");
            AddColumn("dbo.Proyectos", "IdCliente", c => c.String());
            CreateIndex("dbo.Proyectos", "Clientes_IdCliente");
            AddForeignKey("dbo.Proyectos", "Clientes_IdCliente", "dbo.Clientes", "IdCliente");
        }
    }
}
