namespace Alquileres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DT2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmuebles", "barrio", c => c.String(nullable: false));
            AddColumn("dbo.Inmuebles", "CiudadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inmuebles", "CiudadId");
            AddForeignKey("dbo.Inmuebles", "CiudadId", "dbo.ciudads", "CiudadId", cascadeDelete: true);
            DropColumn("dbo.Inmuebles", "colonia");
            DropColumn("dbo.Inmuebles", "ciudad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inmuebles", "ciudad", c => c.String(nullable: false));
            AddColumn("dbo.Inmuebles", "colonia", c => c.String(nullable: false));
            DropForeignKey("dbo.Inmuebles", "CiudadId", "dbo.ciudads");
            DropIndex("dbo.Inmuebles", new[] { "CiudadId" });
            DropColumn("dbo.Inmuebles", "CiudadId");
            DropColumn("dbo.Inmuebles", "barrio");
        }
    }
}
