namespace AbstractMotorFactoryServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StoreDetails", "Engine_Id", "dbo.Engines");
            DropForeignKey("dbo.StoreDetails", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.StoreDetails", "DetailId", "dbo.Details");
            DropIndex("dbo.StoreDetails", new[] { "StoreId" });
            DropIndex("dbo.StoreDetails", new[] { "DetailId" });
            DropIndex("dbo.StoreDetails", new[] { "Engine_Id" });
            CreateTable(
                "dbo.StoreDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        DetailId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.DetailId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.DetailId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.StoreDetails");
            DropTable("dbo.Stores");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        DetailId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Engine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.StoreDetails", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.StoreDetails", "DetailId", "dbo.Details");
            DropIndex("dbo.StoreDetails", new[] { "DetailId" });
            DropIndex("dbo.StoreDetails", new[] { "StoreId" });
            DropTable("dbo.Stores");
            DropTable("dbo.StoreDetails");
            CreateIndex("dbo.StoreDetails", "Engine_Id");
            CreateIndex("dbo.StoreDetails", "DetailId");
            CreateIndex("dbo.StoreDetails", "StoreId");
            AddForeignKey("dbo.StoreDetails", "DetailId", "dbo.Details", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StoreDetails", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StoreDetails", "Engine_Id", "dbo.Engines", "Id");
        }
    }
}
