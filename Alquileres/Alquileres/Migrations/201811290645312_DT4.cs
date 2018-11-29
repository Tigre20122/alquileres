namespace Alquileres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DT4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sucursales", "calles", c => c.String());
            AddColumn("dbo.Sucursales", "telefono", c => c.String());
            DropColumn("dbo.Sucursales", "Tipo");
            DropColumn("dbo.Sucursales", "Nhabitaciones");
            DropColumn("dbo.Sucursales", "CostoMensual");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sucursales", "CostoMensual", c => c.String());
            AddColumn("dbo.Sucursales", "Nhabitaciones", c => c.String());
            AddColumn("dbo.Sucursales", "Tipo", c => c.String());
            DropColumn("dbo.Sucursales", "telefono");
            DropColumn("dbo.Sucursales", "calles");
        }
    }
}
