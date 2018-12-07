namespace Marfrig.CompraGado.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValorTotalItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompraGadoItem", "ValorTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompraGadoItem", "ValorTotal");
        }
    }
}
