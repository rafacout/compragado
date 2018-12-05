namespace Marfrig.CompraGado.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        Preco = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pecurista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pecurista");
            DropTable("dbo.Animal");
        }
    }
}
