namespace Alquileres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DT3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmuebles", "NumeroHabitaciones", c => c.String(nullable: false));
            AddColumn("dbo.Inmuebles", "CostoMensual", c => c.String(nullable: false));
            AddColumn("dbo.Inmuebles", "PropietarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inmuebles", "PropietarioId");
            AddForeignKey("dbo.Inmuebles", "PropietarioId", "dbo.Propietarios", "PropietarioId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inmuebles", "PropietarioId", "dbo.Propietarios");
            DropIndex("dbo.Inmuebles", new[] { "PropietarioId" });
            DropColumn("dbo.Inmuebles", "PropietarioId");
            DropColumn("dbo.Inmuebles", "CostoMensual");
            DropColumn("dbo.Inmuebles", "NumeroHabitaciones");
        }
    }
}
