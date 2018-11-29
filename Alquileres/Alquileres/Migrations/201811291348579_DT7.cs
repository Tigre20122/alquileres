namespace Alquileres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DT7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ciudads", "Detalle", c => c.String(nullable: false));
            AlterColumn("dbo.Contratoes", "ModoPago", c => c.String(nullable: false));
            AlterColumn("dbo.Contratoes", "DuracionContrato", c => c.String(nullable: false));
            AlterColumn("dbo.Sucursales", "Barrio", c => c.String(nullable: false));
            AlterColumn("dbo.Sucursales", "calles", c => c.String(nullable: false));
            AlterColumn("dbo.Sucursales", "telefono", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sucursales", "telefono", c => c.String());
            AlterColumn("dbo.Sucursales", "calles", c => c.String());
            AlterColumn("dbo.Sucursales", "Barrio", c => c.String());
            AlterColumn("dbo.Contratoes", "DuracionContrato", c => c.String());
            AlterColumn("dbo.Contratoes", "ModoPago", c => c.String());
            AlterColumn("dbo.ciudads", "Detalle", c => c.String());
        }
    }
}
