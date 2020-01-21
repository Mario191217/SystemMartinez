namespace SystemMartinezCV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblEmpleados",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Dui = c.String(),
                        Nit = c.String(),
                        Email = c.String(),
                        Genero = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Direccion = c.String(),
                        EstadoEliminar = c.String(),
                    })
                .PrimaryKey(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Tblusuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Clave = c.String(),
                        IdEmpleado = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.TblEmpleados", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.TblRoles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.TblRoles",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdRol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tblusuarios", "IdRol", "dbo.TblRoles");
            DropForeignKey("dbo.Tblusuarios", "IdEmpleado", "dbo.TblEmpleados");
            DropIndex("dbo.Tblusuarios", new[] { "IdRol" });
            DropIndex("dbo.Tblusuarios", new[] { "IdEmpleado" });
            DropTable("dbo.TblRoles");
            DropTable("dbo.Tblusuarios");
            DropTable("dbo.TblEmpleados");
        }
    }
}
