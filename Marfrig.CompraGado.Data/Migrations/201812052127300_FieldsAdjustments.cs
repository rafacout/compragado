namespace Marfrig.CompraGado.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldsAdjustments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animal", "Descricao", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Animal", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Pecurista", "Nome", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pecurista", "Nome", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Animal", "Preco", c => c.Single(nullable: false));
            AlterColumn("dbo.Animal", "Descricao", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
