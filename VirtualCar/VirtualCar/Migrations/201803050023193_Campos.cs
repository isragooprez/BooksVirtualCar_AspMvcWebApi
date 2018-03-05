namespace VirtualCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Campos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombres", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Apellidos", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Direccion", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Telefono", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "DNI", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DNI");
            DropColumn("dbo.AspNetUsers", "Telefono");
            DropColumn("dbo.AspNetUsers", "Direccion");
            DropColumn("dbo.AspNetUsers", "Apellidos");
            DropColumn("dbo.AspNetUsers", "Nombres");
        }
    }
}
