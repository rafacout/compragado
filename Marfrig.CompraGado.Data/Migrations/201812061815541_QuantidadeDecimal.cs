namespace Marfrig.CompraGado.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantidadeDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompraGadoItem", "Quantidade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompraGadoItem", "Quantidade", c => c.Single(nullable: false));
        }
    }
}
