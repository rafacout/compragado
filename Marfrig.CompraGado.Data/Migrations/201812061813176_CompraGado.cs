namespace Marfrig.CompraGado.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompraGado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompraGadoItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompraGadoId = c.Int(nullable: false),
                        Quantidade = c.Single(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animal", t => t.AnimalId)
                .ForeignKey("dbo.CompraGado", t => t.CompraGadoId)
                .Index(t => t.CompraGadoId)
                .Index(t => t.AnimalId);
            
            CreateTable(
                "dbo.CompraGado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataEntrega = c.DateTime(nullable: false),
                        PecuaristaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pecurista", t => t.PecuaristaId)
                .Index(t => t.PecuaristaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompraGadoItem", "CompraGadoId", "dbo.CompraGado");
            DropForeignKey("dbo.CompraGado", "PecuaristaId", "dbo.Pecurista");
            DropForeignKey("dbo.CompraGadoItem", "AnimalId", "dbo.Animal");
            DropIndex("dbo.CompraGado", new[] { "PecuaristaId" });
            DropIndex("dbo.CompraGadoItem", new[] { "AnimalId" });
            DropIndex("dbo.CompraGadoItem", new[] { "CompraGadoId" });
            DropTable("dbo.CompraGado");
            DropTable("dbo.CompraGadoItem");
        }
    }
}
