namespace Alquileres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ciudads", "ProvinciaId", c => c.Int(nullable: false));
            AddColumn("dbo.Sucursales", "EmpleadoId", c => c.Int(nullable: false));
            AddColumn("dbo.Sucursales", "CiudadId", c => c.Int(nullable: false));
            AddColumn("dbo.Sucursales", "Barrio", c => c.String());
            AddColumn("dbo.Sucursales", "Tipo", c => c.String());
            AddColumn("dbo.Sucursales", "Nhabitaciones", c => c.String());
            AddColumn("dbo.Sucursales", "CostoMensual", c => c.String());
            CreateIndex("dbo.ciudads", "ProvinciaId");
            CreateIndex("dbo.Sucursales", "EmpleadoId");
            CreateIndex("dbo.Sucursales", "CiudadId");
            AddForeignKey("dbo.ciudads", "ProvinciaId", "dbo.Provincias", "ProvinciaId", cascadeDelete: true);
            AddForeignKey("dbo.Sucursales", "CiudadId", "dbo.ciudads", "CiudadId", cascadeDelete: true);
            AddForeignKey("dbo.Sucursales", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sucursales", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Sucursales", "CiudadId", "dbo.ciudads");
            DropForeignKey("dbo.ciudads", "ProvinciaId", "dbo.Provincias");
            DropIndex("dbo.Sucursales", new[] { "CiudadId" });
            DropIndex("dbo.Sucursales", new[] { "EmpleadoId" });
            DropIndex("dbo.ciudads", new[] { "ProvinciaId" });
            DropColumn("dbo.Sucursales", "CostoMensual");
            DropColumn("dbo.Sucursales", "Nhabitaciones");
            DropColumn("dbo.Sucursales", "Tipo");
            DropColumn("dbo.Sucursales", "Barrio");
            DropColumn("dbo.Sucursales", "CiudadId");
            DropColumn("dbo.Sucursales", "EmpleadoId");
            DropColumn("dbo.ciudads", "ProvinciaId");
        }
    }
}
